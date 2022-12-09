using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    public ProceduralGeneration proceduralGeneration;

    void Start()
    {
        proceduralGeneration = GameObject.Find("ProceduralGeneration").GetComponent<ProceduralGeneration>();
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z + 0.01f);

        CheckDistance();
    }

    public void CheckDistance()
    {
        if(gameObject.transform.position.z > 10)
        {
            Destroy(gameObject);
           proceduralGeneration.SpawnObstacles(2);
        }
    }
}
