using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

public enum MoveState
{
    Idle,
    SneakWalk,
    StationaryWalk,
    StationaryRun,
    FreeWalk
}

public struct Vector3Struct
{
    public float x, y, z;

    public Vector3Struct(float x, float y, float z)
    {
        this.x = x; this.y = y; this.z = z;
    }

    public static Vector3Struct operator +(Vector3Struct a, Vector3Struct b) =>
        new Vector3Struct(a.x + b.x, a.y + b.y, a.z + b.z);

    public static Vector3Struct operator -(Vector3Struct a, Vector3Struct b) =>
    new Vector3Struct(a.x - b.x, a.y - b.y, a.z - b.z);

    public static Vector3Struct operator /(Vector3Struct a, float d) =>
        new Vector3Struct(a.x / d, a.y / d, a.z / d);

    public static Vector3Struct operator *(Vector3Struct a, float d) =>
        new Vector3Struct(a.x * d, a.y * d, a.z * d);

    public static Vector3Struct operator *(float d, Vector3Struct a) =>
        new Vector3Struct(a.x * d, a.y * d, a.z * d);

    public float DistanceTo(Vector3Struct other)
    {
        float dx = x - other.x;
        float dy = y - other.y;
        float dz = z - other.z;
        return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
}

public struct MarkerData
{
    public int iFrame;
    public Vector3Struct LeftFoot;
    public Vector3Struct RightFoot;
    public Vector3Struct Center;
    public double Timestamp;
}

public class MotionAnalyzer
{
    private List<MarkerData> buffer = new List<MarkerData>();
    private const float StepThresholdY = 0.012f;
    private const float StepVelocityThresholdY = 0.3f;
    private const float CenterMovementThreshold = 0.1f;
    private const double MaxBufferSeconds = 2.0;
    private readonly object lockObj = new object();

    private string logFilePath = null;
    private bool logHeaderWritten = false;

    public MoveState CurrentState { get; private set; } = MoveState.Idle;
    public float WalkingSpeed { get; private set; }
    public float StepInterval { get; private set; }
    public float MaxFootHeight { get; private set; }
    public float MaxStride { get; private set; }
    public int StepCount { get; private set; }

    private float lastLeftVy = 0f;
    private float lastRightVy = 0f;
    private float lastAvgYMove = 0f;
    private float lastRotationAmount = 0f;

    public MoveState GetState() { lock (lockObj) return CurrentState; }
    public float GetSpeed() { lock (lockObj) return WalkingSpeed; }
    public float GetCount() { lock (lockObj) return buffer.Count; }
    public float GetStepInterval() { lock (lockObj) return StepInterval; }
    public float GetMaxFootHeight() { lock (lockObj) return MaxFootHeight; }
    public float GetMaxStride() { lock (lockObj) return MaxStride; }
    public float GetStepCount() { lock (lockObj) return StepCount; }

    public void SetLogFile(string path)
    {
        lock (lockObj)
        {
            logFilePath = path;
            logHeaderWritten = false;
        }
    }

    public void AddData(MarkerData data)
    {
        lock (lockObj)
        {
            buffer.Add(data);
            double latest = data.Timestamp;
            buffer.RemoveAll(d => latest - d.Timestamp > MaxBufferSeconds);
            AdaptiveAnalyze();
        }
    }

    private void AdaptiveAnalyze()
    {
        if (buffer.Count < 3) return;
        float avgStepInterval = EstimateAverageStepInterval(buffer);
        float windowTime = Clamp(avgStepInterval * 2.5f, 0.4f, 1.5f);
        var window = GetRecentWindow(windowTime);
        if (window.Count < 3) return;
        AnalyzeMovement(window);
    }

    private List<MarkerData> GetRecentWindow(float windowSeconds)
    {
        double latest = buffer.Last().Timestamp;
        return buffer.Where(d => latest - d.Timestamp <= windowSeconds).ToList();
    }

    private float EstimateAverageStepInterval(List<MarkerData> list)
    {
        List<double> peaks = new List<double>();
        bool leftUp = false, rightUp = false;

        for (int i = 1; i < list.Count; i++)
        {
            var prev = list[i - 1];
            var curr = list[i];
            double dt = curr.Timestamp - prev.Timestamp;

            lastLeftVy = (float)((curr.LeftFoot.y - prev.LeftFoot.y) / dt);
            lastRightVy = (float)((curr.RightFoot.y - prev.RightFoot.y) / dt);

            if (!leftUp && lastLeftVy > StepVelocityThresholdY)
            {
                peaks.Add(curr.Timestamp);
                leftUp = true;
            }
            else if (leftUp && lastLeftVy < -StepVelocityThresholdY)
                leftUp = false;

            if (!rightUp && lastRightVy > StepVelocityThresholdY)
            {
                peaks.Add(curr.Timestamp);
                rightUp = true;
            }
            else if (rightUp && lastRightVy < -StepVelocityThresholdY)
                rightUp = false;
        }

        if (peaks.Count < 3) return float.MaxValue;

        List<float> intervals = new List<float>();
        for (int i = 1; i < peaks.Count; i++)
            intervals.Add((float)(peaks[i] - peaks[i - 1]));

        return intervals.Average();
    }

    private void AnalyzeMovement(List<MarkerData> list)
    {
        float rotationAmount;
        float centerMove = ComputeCenterMovement(list, out rotationAmount);
        lastRotationAmount = rotationAmount;

        float leftMin = list.Min(d => d.LeftFoot.y);
        float rightMin = list.Min(d => d.RightFoot.y);

        float leftYMove = list.Max(d => d.LeftFoot.y - leftMin);
        float rightYMove = list.Max(d => d.RightFoot.y - rightMin);
        float avgYMove = (leftYMove + rightYMove) / 2;

        MaxFootHeight = Math.Max(leftYMove, rightYMove);
        lastAvgYMove = avgYMove;

        MaxStride = list.Max(d =>
        {
            var l = d.LeftFoot;
            var r = d.RightFoot;
            float dx = l.x - r.x, dz = l.z - r.z;
            return (float)Math.Sqrt(dx * dx + dz * dz);
        });

        StepCount = EstimateStepCount(list);
        double timeDelta = list.Last().Timestamp - list.First().Timestamp;
        StepInterval = (float)(timeDelta / Math.Max(1, StepCount));

        bool isRotating = rotationAmount > 0.4f;
        bool isCenterMoving = centerMove > CenterMovementThreshold;
        bool isStepDetected = avgYMove > 0.01f && StepCount >= 2;

        // ✅ FreeWalk -> Idle 전이 조건 추가
        if (CurrentState == MoveState.FreeWalk &&
            !isCenterMoving && !isRotating &&
            avgYMove < 0.01f && StepCount < 2)
        {
            CurrentState = MoveState.Idle;
            WalkingSpeed = 0f;
            LogAnalysis(list.Last(), centerMove, avgYMove);
            return;
        }

        if (CurrentState == MoveState.Idle && (isCenterMoving || isRotating))
        {
            CurrentState = MoveState.FreeWalk;
            WalkingSpeed = 0f;
            LogAnalysis(list.Last(), centerMove, avgYMove);
            return;
        }

        if (StepCount >= 2 && avgYMove > 0.01f && avgYMove < 0.03f)
        {
            CurrentState = MoveState.SneakWalk;
        }
        else if (StepCount >= 3 && avgYMove >= 0.03f)
        {
            if (StepInterval < 0.25f && MaxFootHeight > 0.12f && MaxStride > 0.1f)
                CurrentState = MoveState.StationaryRun;
            else
                CurrentState = MoveState.StationaryWalk;
        }
        else
        {
            CurrentState = MoveState.Idle;
            WalkingSpeed = 0f;
            LogAnalysis(list.Last(), centerMove, avgYMove);
            return;
        }

        WalkingSpeed = EstimateVirtualSpeed(StepInterval, MaxFootHeight, MaxStride);
        LogAnalysis(list.Last(), centerMove, avgYMove);
    }

    private float ComputeCenterMovement(List<MarkerData> list, out float rotationAmount)
    {
        if (list.Count < 2)
        {
            rotationAmount = 0f;
            return 0f;
        }

        var first = list.First();
        var last = list.Last();

        Vector3Struct footDir1 = Normalize(first.RightFoot - first.LeftFoot);
        Vector3Struct footDir2 = Normalize(last.RightFoot - last.LeftFoot);

        Vector3Struct forward1 = new Vector3Struct(-footDir1.z, 0f, footDir1.x); // ← Z-up 가정
        Vector3Struct forward2 = new Vector3Struct(-footDir2.z, 0f, footDir2.x);

        float dot = forward1.x * forward2.x + forward1.z * forward2.z;
        dot = Clamp(dot, -1f, 1f);
        rotationAmount = (float)Math.Acos(dot);

        return first.Center.DistanceTo(last.Center);
    }

    private Vector3Struct Normalize(Vector3Struct v)
    {
        float mag = (float)Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        return mag > 0 ? new Vector3Struct(v.x / mag, v.y / mag, v.z / mag) : new Vector3Struct(0, 0, 0);
    }

    private void LogAnalysis(MarkerData latest, float centerMove, float avgYMove)
    {
        if (string.IsNullOrEmpty(logFilePath)) return;

        string line = string.Format(
            System.Globalization.CultureInfo.InvariantCulture,
            "{0:F3},{1:F3},{2:F3},{3:F3},{4:F3},{5:F3},{6:F3},{7:F3},{8:F3},{9:F3},{10:F3},{11:F3},{12:F3},{13:F3},{14},{15:F3},{16:F3},{17:F3},{18:F3},{19:F3},{20},{21:F3}",
            latest.Timestamp,
            latest.LeftFoot.x, latest.LeftFoot.y, latest.LeftFoot.z,
            latest.RightFoot.x, latest.RightFoot.y, latest.RightFoot.z,
            latest.Center.x, latest.Center.y, latest.Center.z,
            lastLeftVy, lastRightVy,
            centerMove, avgYMove,
            StepCount, StepInterval, MaxFootHeight, MaxStride, WalkingSpeed,
            (int)CurrentState, CurrentState,
            lastRotationAmount
        );

        lock (lockObj)
        {
            bool writeHeader = !logHeaderWritten;
            logHeaderWritten = true;

            using (var writer = new StreamWriter(logFilePath, true))
            {
                if (writeHeader)
                {
                    writer.WriteLine("Timestamp,LeftX,LeftY,LeftZ,RightX,RightY,RightZ,CenterX,CenterY,CenterZ,LeftVy,RightVy,CenterMove,AvgYMove,StepCount,StepInterval,FootHeight,Stride,Speed,StateInt,State,Rotation");
                }
                writer.WriteLine(line);
            }
        }
    }

    private int EstimateStepCount(List<MarkerData> list)
    {
        int count = 0;
        bool leftUp = false, rightUp = false;

        for (int i = 1; i < list.Count; i++)
        {
            var prev = list[i - 1];
            var curr = list[i];
            double dt = curr.Timestamp - prev.Timestamp;

            float leftVy = (float)((curr.LeftFoot.y - prev.LeftFoot.y) / dt);
            float rightVy = (float)((curr.RightFoot.y - prev.RightFoot.y) / dt);

            if (!leftUp && leftVy > StepVelocityThresholdY)
            {
                count++;
                leftUp = true;
            }
            else if (leftUp && leftVy < -StepVelocityThresholdY)
                leftUp = false;

            if (!rightUp && rightVy > StepVelocityThresholdY)
            {
                count++;
                rightUp = true;
            }
            else if (rightUp && rightVy < -StepVelocityThresholdY)
                rightUp = false;
        }

        return count;
    }

    private float EstimateVirtualSpeed(float stepInterval, float footHeight, float stride)
    {
        float speed = 1f / Math.Max(0.15f, stepInterval);
        float strideFactor = Clamp(stride / 0.25f, 0.5f, 2f);
        float heightFactor = Clamp01((footHeight - 0.03f) / 0.1f);
        return speed * strideFactor * (0.5f + heightFactor);
    }

    private float Clamp(float val, float min, float max) => Math.Max(min, Math.Min(max, val));
    private float Clamp01(float val) => Clamp(val, 0f, 1f);
}