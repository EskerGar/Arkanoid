using Ball;
using UnityEngine;
using static Borders;
using Random = UnityEngine.Random;

public class InputController : MonoBehaviour
{
    [SerializeField] private PlayerGeneration playerGeneration;
    
    private BallBehaviour _ball;
    private Platform.Platform _platform;
    private Camera _cam;
    private Vector3 _firstDir;

    private void Awake()
    {
        _cam = Camera.main;
        playerGeneration.OnCreatePlatform += GetPlatform;
        playerGeneration.OnCreateBall += GetBall;
    }

    private void GetBall(BallBehaviour ball) 
    {
        _ball = ball;
    }

    private void GetPlatform(Platform.Platform platform) => _platform = platform;

    private void Update()
    {
        SetPlatformPos(GetMousePos().x);
        if(_platform.transform.position.x < LeftBorder)
            SetPlatformPos(LeftBorder);
        else if (_platform.transform.position.x > RightBorder)
            SetPlatformPos(RightBorder);
        if (!Input.GetMouseButtonDown(0) || !_ball.IsBallStay) return;
        _ball.IsBallStay = false;
        _ball.Dir = new Vector3(Random.Range(LeftBorder, RightBorder), 1f);
    }

    private void SetPlatformPos(float xPos)
    {
        _platform.transform.position = new Vector3(xPos, _platform.transform.position.y);
        if(_ball.IsBallStay)
            _ball.transform.position = new Vector3(xPos, _ball.transform.position.y);
    }

    private Vector3 GetMousePos()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = _cam.ScreenToWorldPoint (mousePos);
        return mousePos;
    }
    
}
