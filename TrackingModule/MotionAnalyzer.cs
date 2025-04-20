using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MotionTracking
{
    public class MotionAnalyzer
    {
        private readonly Queue<MarkerData> buffer = new Queue<MarkerData>();
        private readonly object lockObj = new object();
        private MoveState currentState = MoveState.Idle;
        private float walkingSpeed = 0; // 제자리 걷기일 때의 가상 속도
        private float movementThreshold = 0.2f; // 실제 이동 판단 기준 (m)
        private float stepHeightThreshold = 0.03f; // 제자리 걷기 판단 기준 (Y축 변화량)

        public void AddFrame(MarkerData data)
        {
            lock (lockObj)
            {
                buffer.Enqueue(data);
                if (buffer.Count > 60) buffer.Dequeue(); // 최근 60개의 데이터를 보유
                Analyze();
            }
        }

        public MoveState GetState()
        {
            lock (lockObj) return currentState;
        }

        public float GetSpeed()
        {
            lock (lockObj) return walkingSpeed;
        }

        public void SetMovementThreshold(float threshold)
        {
            lock (lockObj) movementThreshold = threshold;
        }

        public void SetStepHeightThreshold(float threshold)
        {
            lock (lockObj) stepHeightThreshold = threshold;
        }

        private void Analyze()
        {
            var list = buffer.ToList();
            if (list.Count < 10) return; // 충분한 데이터가 없다면 처리하지 않음

            // 1. 중심점 이동 거리 측정
            Vector3 firstCenter = (list.First().LeftFoot + list.First().RightFoot) / 2;
            Vector3 lastCenter = (list.Last().LeftFoot + list.Last().RightFoot) / 2;
            float centerMovement = Vector3.Distance(firstCenter, lastCenter);

            // 2. 발의 Y축 상하 움직임 분석 (걷고 있는지 판단)
            float leftYMove = list.Max(d => d.LeftFoot.Y) - list.Min(d => d.LeftFoot.Y);
            float rightYMove = list.Max(d => d.RightFoot.Y) - list.Min(d => d.RightFoot.Y);
            float avgYMove = (leftYMove + rightYMove) / 2;

            if (centerMovement > movementThreshold)
            {
                currentState = MoveState.FreeWalk;
                walkingSpeed = 0f;
            }
            else if (avgYMove > stepHeightThreshold)
            {
                currentState = MoveState.StationaryWalk;

                // 3. 제자리 걷기 속도 계산 (가상의 걷는 속도 추정)
                double timeDelta = list.Last().Timestamp - list.First().Timestamp;
                int stepCount = EstimateStepCount(list);
                walkingSpeed = (float)((stepCount / 2.0) / timeDelta); // 한 걸음에 2스텝 (좌우 발 각각 1스텝)
            }
            else
            {
                currentState = MoveState.Idle;
                walkingSpeed = 0f;
            }
        }

        private int EstimateStepCount(List<MarkerData> buffer)
        {
            // 발이 들리는 이벤트(Y축이 기준 이상)를 카운트하여 스텝 수 추정
            float threshold = 0.03f;
            int steps = 0;
            bool leftUp = false, rightUp = false;

            for (int i = 1; i < buffer.Count; i++)
            {
                if (!leftUp && buffer[i].LeftFoot.Y - buffer[i - 1].LeftFoot.Y > threshold)
                {
                    steps++;
                    leftUp = true;
                }
                else if (leftUp && buffer[i].LeftFoot.Y - buffer[i - 1].LeftFoot.Y < -threshold)
                {
                    leftUp = false;
                }

                if (!rightUp && buffer[i].RightFoot.Y - buffer[i - 1].RightFoot.Y > threshold)
                {
                    steps++;
                    rightUp = true;
                }
                else if (rightUp && buffer[i].RightFoot.Y - buffer[i - 1].RightFoot.Y < -threshold)
                {
                    rightUp = false;
                }
            }

            return steps;
        }
    }
}
