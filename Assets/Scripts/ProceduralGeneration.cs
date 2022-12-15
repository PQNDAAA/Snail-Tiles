using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject roadPrefab;
    public GameObject[] Obstacles;
    public GameObject playerGameObject;
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
        SpawnPlayer();
        SpawnObstacles();
    }


    public void SpawnObstacles()
    {
        int indexRandom = Random.RandomRange(0, spawnXLocationObstacles.Count);

        for (int i = 0; i < indexRandom; i++)
        {
            Instantiate(RandomObstacles(), RandomVector(), Quaternion.identity);
        }
    }
    public void SpawnPlayer()
    {
        Instantiate(playerGameObject,new Vector3(10,1,0), Quaternion.identity);
    }

    public GameObject RandomObstacles()
    {
        int indexObstacles = Random.RandomRange(0, Obstacles.Length);
        return Obstacles[indexObstacles];
    }

    public Vector3 RandomVector()
    {
        int indexVector = Random.RandomRange(0, spawnXLocationObstacles.Count);
        return spawnXLocationObstacles[indexVector];
    }
}
