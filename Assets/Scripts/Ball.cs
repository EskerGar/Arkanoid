using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float _speed = 5f;
    private float _leftBorder;
    private float _rightBorder;
    private float _upBorder;
    private float _downBorder;
    public Vector3 Dir { get; set; }
    public bool IsBallStay { get; set; } = true;

    private void Update()
    {
        if (IsBallStay) return;
        SetDirectMove(Dir);
        CheckBorders();
    }

    private void SetDirectMove(Vector3 direct)
    {
        transform.position += direct.normalized * (_speed * Time.deltaTime);
    }

    public void SetBorders(float left, float right, float up, float down)
    {
        _leftBorder = left;
        _rightBorder = right;
        _upBorder = up;
        _downBorder = down;
    }

    private void CheckBorders()
    {
        var pos = transform.position;
        if(pos.y < _downBorder)
        {
            Dead();
            return;
        }
        if(transform.position.x < _leftBorder)
            Dir = FindReflection(Dir, new Vector3(1, 0));
        else if(transform.position.x > _rightBorder)
            Dir = FindReflection(Dir, new Vector3(-1, 0));
        else if(transform.position.y > _upBorder)
            Dir = FindReflection(Dir, new Vector3(0, -1));
    }

    private void Dead()
    {

    }

    private Vector3 FindReflection(Vector3 a, Vector3 b)
    {
        return Vector3.Reflect(a, b.normalized);
    }
}
