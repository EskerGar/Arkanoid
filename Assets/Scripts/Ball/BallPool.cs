namespace Ball
{
        public static class BallPool
        {
                public static int BallCount { get; private set; }
                public static void AddBall() => BallCount++;

                public static void RemoveBall() => BallCount--;
        }
}