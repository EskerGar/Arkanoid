using UnityEngine;

namespace Bonuse
{
    public class SpeedBonuse : IBonuse
    {
        private const int MINSpeed = 5;
        private const int MAXSpeed = 15;

        public void BonuseLogic()
        {
            var newSpeed = NewSpeed();
            foreach (var ball in PlayerGeneration.Balls)
            {
                ball.Speed = newSpeed;
            }
        }

        private float NewSpeed() => Random.Range(MINSpeed, MAXSpeed);
    }
}