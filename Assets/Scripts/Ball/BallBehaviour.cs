using System;
using System.Linq;
using Cubes;
using UnityEngine;
using static Borders;
using static Ball.BallPool;

namespace Ball
{
    public class BallBehaviour : MonoBehaviour
    {
        [SerializeField] private float speed = 7f;

        public Vector3 Dir { get; set; }
        public bool IsBallStay { get; set; } = true;

        public float Speed
        {
            set => speed = value;
        }

        private Platform.Platform _platform;

        public void Initialize(Platform.Platform platform)
        {
            _platform = platform;
        }
    
        private void Update()
        {
            if (IsBallStay) return;
            SetDirectMove(Dir);
            CheckBorders();
            CheckCube();
            CheckPlatform();
        }

        private void SetDirectMove(Vector3 direct)
        {
            transform.position += direct.normalized * (speed * Time.deltaTime);
        }

        private void CheckBorders()
        {
            var pos = transform.position + Dir.normalized * transform.localScale.x / 2;
            if(pos.y < DownBorder)
            {
                Dead();
                return;
            }
        
            if(pos.x < LeftBorder)
                Dir = Vector3.Reflect(Dir.normalized, Vector3.right);
            else if(pos.x > RightBorder)
                Dir = Vector3.Reflect(Dir.normalized, Vector3.left);
            else if(pos.y > UpBorder)
                Dir = Vector3.Reflect(Dir.normalized, Vector3.down);
        }

        private void CheckCube()
        {
            foreach (var cube in CubeGeneration.CubeList.Where(cube => CheckObject(cube.gameObject)))
            {
                cube.TakeDamage();
            }
        }

        private void CheckPlatform()
        {
            CheckObject(_platform.gameObject);
        }

        private bool CheckObject(GameObject obj)
        {
            const float difference = 0.08f;
            var pos = obj.transform.position;
            var scale = obj.transform.localScale;
            var dirEnd = transform.position + Dir.normalized * transform.localScale.x / 2;
            float[] axeX = {pos.x - scale.x / 2, pos.x + scale.x / 2};
            float[] axeY = {pos.y - scale.y / 2, pos.y + scale.y / 2};
        
            if (dirEnd.x >= axeX[0] && dirEnd.x <= axeX[1] && Math.Abs(dirEnd.y - axeY[0]) <= difference)
                Dir = Vector3.Reflect(Dir.normalized, Vector3.down);
            else if (dirEnd.y >= axeY[0] && dirEnd.y <= axeY[1] && Math.Abs(dirEnd.x - axeX[0]) <= difference)
                Dir = Vector3.Reflect(Dir.normalized, Vector3.left);
            else if (dirEnd.y >= axeY[0] && dirEnd.y <= axeY[1] && Math.Abs(dirEnd.x - axeX[1]) <= difference)
                Dir = Vector3.Reflect(Dir.normalized, Vector3.right);
            else if (dirEnd.x >= axeX[0] && dirEnd.x <= axeX[1] && Math.Abs(dirEnd.y - axeY[1]) <= difference)
                Dir = Vector3.Reflect(Dir.normalized, Vector3.up);
            else 
                return false;
            return true;
        }

        private void Dead()
        {
            RemoveBall();
            if(BallCount == 0)
                Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
}
