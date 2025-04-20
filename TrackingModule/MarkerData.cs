using System.Numerics;

namespace MotionTracking
{
    public struct MarkerData
    {
        public int iFrame;
        public Vector3 LeftFoot;
        public Vector3 RightFoot;
        public double Timestamp;
    }
}
