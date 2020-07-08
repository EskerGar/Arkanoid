using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InputController : MonoBehaviour
{
    private const float LeftBorder = -8.75f;
    private const float RightBorder = 8.75f;
    private const float UpBorder = 4.85f;
    private const float DownBorder = -5f;
    
    private Ball _ball;
    private Platform _platform;
    private Camera _cam;
    private Vector3 _firstDir;
    [SerializeField] private PlayerGeneration playerGeneration;

    private void Awake()
    {
        _cam = Camera.main;
        playerGeneration.OnCreatePlatform += GetPlatform;
        playerGeneration.OnCreateBall += GetBall;
    }

    private void GetBall(Ball ball) 
    {
        _ball = ball;
        _ball.SetBorders(LeftBorder, RightBorder, UpBorder, DownBorder);
    }

    private void GetPlatform(Platform platform) => _platform = platform;

    private void Update()
    {
        SetPlatformPos(GetMousePos().x);
        if(_platform.transform.position.x < LeftBorder)
            SetPlatformPos(LeftBorder);
        else if (_platform.transform.position.x > RightBorder)
            SetPlatformPos(RightBorder);
        if (Input.GetMouseButtonDown(0))
        {
            _ball.IsBallStay = false;
            _ball.Dir = new Vector3(Random.Range(LeftBorder, RightBorder), 1f);
        }
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
