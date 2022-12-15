using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    public ProceduralGeneration proceduralGeneration;
    public Vector3 thisPos = new Vector3();

    void Start()
    {
        proceduralGeneration = GameObject.Find("ProceduralGeneration").GetComponent<ProceduralGeneration>();

        thisPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);   
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z + 0.01f);

        CheckDistance();
    }

    public void CheckDistance()
    {
        if(gameObject.transform.position.z >= 10)
        {
            Instantiate(proceduralGeneration.RandomObstacles(), thisPos, Quaternion.identity);
            Destroy(gameObject);   
          
        }
    }
}
