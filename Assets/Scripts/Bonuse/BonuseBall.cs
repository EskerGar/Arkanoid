using UnityEngine;
using static Borders;

namespace Bonuse
{
    public class BonuseBall : IBonuse
    {
        public void BonuseLogic()
        {
            var ball = Object.FindObjectOfType<PlayerGeneration>().BallCreate(Object.FindObjectOfType<Platform.Platform>().gameObject);
            ball.IsBallStay = false;
            ball.Dir = new Vector3(Random.Range(LeftBorder, RightBorder), 1f);
        }
    }
}