using System;
using System.Collections.Generic;
using Ball;
using UnityEngine;
using static Ball.BallPool;

public class PlayerGeneration : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject ballPrefab;

    public static List<BallBehaviour> Balls { get; } = new List<BallBehaviour>();
    
    public event Action<Platform.Platform> OnCreatePlatform;
    public event Action<BallBehaviour> OnCreateBall;

    private void Start()
    {
        var platform = CreatePlatform();
        OnCreatePlatform?.Invoke(platform.GetComponent<Platform.Platform>());
        var ball = BallCreate(platform);
        OnCreateBall?.Invoke(ball);
    }

    private GameObject CreatePlatform()
    {
        return Instantiate(platformPrefab, transform.position, Quaternion.identity);
    }

    public BallBehaviour BallCreate(GameObject platform)
    {
        var platformTrans = platform.transform;
        var ballPos = platformTrans.position + new Vector3(0, platformTrans.localScale.y / 2 + ballPrefab.transform.localScale.y / 2);
        var ball = Instantiate(ballPrefab, ballPos, Quaternion.identity);
        var ballBehaviour = ball.GetComponent<BallBehaviour>();
        ballBehaviour.Initialize(platform.GetComponent<Platform.Platform>());
        Balls.Add(ballBehaviour);
        AddBall();
        return ballBehaviour;
    }
    
}
