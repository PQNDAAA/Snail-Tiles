using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherycObstacle : AbstractObstacles
{
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        speedObstacles = 0.005f;
    }
    public override void Update()
    {
        maxSpeedObstacles = speedObstacles + gameManager.speedMovement;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z + maxSpeedObstacles);


    }
}
