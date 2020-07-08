using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGeneration : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Vector3 offset;
    [SerializeField] private int columns = 10;
    [SerializeField] private int rows = 5;

    private void Start()
    {
        GenerateField();
    }

    private void CreateCube(Vector2 offset, int i, int j)
    {
        var cube = Instantiate(
            cubePrefab,
            (Vector2)transform.position + offset * new Vector2(j, i),
            Quaternion.identity);
    }

    private void GenerateField()
    {
        for(int i = 0; i < rows; i++)
        for(int j = 0; j < columns; j++) 
                CreateCube(offset, i, j);
    }
}
