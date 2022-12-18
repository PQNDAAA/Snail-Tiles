using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    //Roads
    public GameObject roadPrefab;

    //Obstacles
    public GameObject[] Obstacles;

    //Player 
    public GameObject playerGameObject;

    //Spawn location entered manually
    public List<Vector3> spawnXLocationObstacles = new List<Vector3>();

    public int spaceX = 5;
    public int spawnRoadXLocation = 0;

    public bool spawnObstacles = true;
    public int indexWaveObstacles = 0;
    public int indexNumberOfObstacles = 0;
    void Start()
    {
        GenerateMap();
    }
    public void GenerateMap()
    {
        //Spawn roads
        for (int i = 0; i < 3; i++)
        {
            spawnRoadXLocation += spaceX;
            Instantiate(roadPrefab, new Vector3(spawnRoadXLocation, 0, 0), Quaternion.identity);
        }
        //Spawn the best snail made by Thomas
        SpawnPlayer();
        //Spawn obstacles
        StartCoroutine(SpawnObstacles(1));
    }


    //Spawn obstacles between 1 & 2 for each wave. There is three roads.
    public IEnumerator SpawnObstacles(int value)
    {
        indexNumberOfObstacles = Random.RandomRange(1, 3);
        Debug.Log("Number obstacles : " + indexNumberOfObstacles);

        //By defaut
        spawnObstacles = true;

        //Spawn each wave with cooldown x seconds
        //indexNumberOfObstacles = Number of Obstacles in each wave 
        while (spawnObstacles && indexWaveObstacles != value)
        { 
            indexWaveObstacles++;
            Debug.Log(indexWaveObstacles + " / " + value);

            for (int i = 0; i < indexNumberOfObstacles; i++)
            {
                Instantiate(RandomObstacles(), RandomVector(), Quaternion.identity);
            }
            spawnObstacles = false;
            yield return new WaitForSeconds(0.5f);
            spawnObstacles = true;

            //Reset all values
            if (indexWaveObstacles == value)
            {
                spawnObstacles = false;
                indexWaveObstacles = 0;
                indexNumberOfObstacles = 0;

                Debug.Log(indexWaveObstacles + " / " + value);
                break;
            }
        }
    }

    //Spawn the Player
    public void SpawnPlayer()
    {
        Instantiate(playerGameObject,new Vector3(10,1,9), Quaternion.identity);
    }

    //The game takes random obstacles/vector
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
