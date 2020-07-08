using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneration : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject ballPrefab;

    public event Action<Platform> OnCreatePlatform;
    public event Action<Ball> OnCreateBall; 
    
    void Start()
    {
        var platform = CreatePlatform();
        OnCreatePlatform?.Invoke(platform.GetComponent<Platform>());
        var ball = BallCreate(platform);
        OnCreateBall?.Invoke(ball.GetComponent<Ball>());
    }

    private GameObject CreatePlatform()
    {
        return Instantiate(platformPrefab, transform.position, Quaternion.identity);
    }

    public GameObject BallCreate(GameObject platform)
    {
        var platformTrans = platform.transform;
        var BallPos = platformTrans.position + new Vector3(0, platformTrans.localScale.y / 2 + ballPrefab.transform.localScale.y / 2);
        return Instantiate(ballPrefab, BallPos, Quaternion.identity);
    }
    
}
