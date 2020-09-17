using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Cubes
{
    public class CubeGeneration : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private int columns = 10;
        [SerializeField] private int rows = 5;
        [SerializeField] private List<GameObject> cubes;
        [SerializeField] [Range(1, 10)] private int maxCubeHealth;
        [SerializeField] private string nextLevel;
        public static List<Cube> CubeList { get; } = new List<Cube>();

        private void Start()
        {
            GenerateField();
        }

        private void Update()
        {
            LoadNextLevel();
        }

        private void CreateCube(Vector2 offset, int i, int j)
        {
            var randomCubeType = Random.Range(0, cubes.Count);
            var cube = Instantiate(
                cubes[randomCubeType],
                (Vector2)transform.position + offset * new Vector2(j, i),
                Quaternion.identity);
            cube.GetComponent<Cube>().Initialize(maxCubeHealth);
            CubeList.Add(cube.GetComponent<Cube>());
        }

        private void GenerateField()
        {
            for(int i = 0; i < rows; i++)
            for(int j = 0; j < columns; j++) 
                CreateCube(offset, i, j);
        }

        private void LoadNextLevel()
        {
            if (CubeList.Count == 0)
                SceneManager.LoadScene(nextLevel);
        }
    }
}
