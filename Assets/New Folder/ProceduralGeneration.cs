using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject roadPrefab;
    public GameObject[] Obstacles;
    public List<Vector3> spawnXLocationObstacles = new List<Vector3>();

    public int spaceX = 5;
    public int spawnRoadXLocation = 0;
    void Start()
    {
        GenerateMap();
    }
    public void GenerateMap()
    {
        for (int i = 0; i < 3; i++)
        {
            spawnRoadXLocation += spaceX;
            Instantiate(roadPrefab, new Vector3(spawnRoadXLocation, 0, 0), Quaternion.identity);
        }
        SpawnObstacles(3);
    }


    public void SpawnObstacles(int value)
    {
        for (int i = 0; i < spawnXLocationObstacles.Count; i++)
        {
            Instantiate(Obstacles[0], spawnXLocationObstacles[i], Quaternion.identity);
        }
       }
    }
