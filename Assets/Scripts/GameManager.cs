using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ProceduralGeneration proceduralGeneration;

    void Start()
    {
        proceduralGeneration = GameObject.Find("ProceduralGeneration").GetComponent<ProceduralGeneration>();
    }

    void Update()
    {
        CheckDistance();
        CheckObstacles();
    }
    public void CheckDistance()
    {
        foreach(GameObject go in FindObstacles())
        {
            if(go.transform.position.z >= 10)
            {
                Destroy(go);
            }
        }
    }
    public void CheckObstacles()
    {
        if(FindObstacles().Length == 0)
        {
            proceduralGeneration.SpawnObstacles();
        }  
    }

    public GameObject[] FindObstacles()
    {
        return GameObject.FindGameObjectsWithTag("Obstacles");
    }
}
