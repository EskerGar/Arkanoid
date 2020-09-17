using System;
using UnityEngine;
using static Borders;

namespace Bonuse
{
    public class BonuseBehaviour : MonoBehaviour
    {
        private const int FallSpeed = 2;
    
        private Platform.Platform _platform;
        private IBonuse _bonuse;

        private void Start()
        {
            _platform = FindObjectOfType<Platform.Platform>();
        }

        private void Update()
        {
            Move();
            if(CheckCollisionWhitPlatform())
            {
                _bonuse.BonuseLogic();
                Destroy(gameObject);
            }
            if(CanOnDestroy())
                Destroy(gameObject);
        }

        public void Initialize(IBonuse bonuse)
        {
            _bonuse = bonuse;
        }

        private bool CheckCollisionWhitPlatform()
        {
            const float difference = 0.08f;
            var bonusePosition = (Vector2)transform.position + Vector2.down * transform.localScale.x / 2;;
            var platformPosition = _platform.transform.position;
            var platformScale = _platform.transform.localScale;
            var platformXAxe = new[] {platformPosition.x - platformScale.x / 2, platformPosition.x + platformScale.x / 2};
            var platformYAxe = new[] {platformPosition.y - platformScale.y / 2, platformPosition.y + platformScale.y / 2};
            return (bonusePosition.x >= platformXAxe[0] && bonusePosition.x <= platformXAxe[1] &&
                    Math.Abs(bonusePosition.y - platformYAxe[0]) <= difference);
        }

        private bool CanOnDestroy() => transform.position.y <= DownBorder;

        private void Move() => transform.position += Vector3.down * (FallSpeed * Time.deltaTime);
    }
}