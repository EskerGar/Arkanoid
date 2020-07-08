using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private const float LeftBorder = -8f;
    private const float RightBorder = 8f;
    
    private Ball _ball;
    private Platform _platform;
    private Camera _cam;
    [SerializeField] private PlayerGeneration playerGeneration;

    private void Awake()
    {
        _cam = Camera.main;
        playerGeneration.OnCreatePlatform += GetPlatform;
        playerGeneration.OnCreateBall += GetBall;
    }

    private void GetBall(Ball ball) => _ball = ball;

    private void GetPlatform(Platform platform) => _platform = platform;

    private void Update()
    {
        SetPlatformPos(GetMousePos().x);
        if(_platform.transform.position.x < LeftBorder)
            SetPlatformPos(LeftBorder);
        else if (_platform.transform.position.x > RightBorder)
            SetPlatformPos(RightBorder);
    }

    private void SetPlatformPos(float xPos) => _platform.transform.position = new Vector3(xPos, _platform.transform.position.y);

    private Vector3 GetMousePos()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = _cam.ScreenToWorldPoint (mousePos);
        return mousePos;
    }
    
}
