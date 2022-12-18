using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherycObstacle : AbstractObstacles
{
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public override void Update()
    {
        //Explained in "AbstractObstacles.cs"
        initialSpeedObstacles = defautSpeedObstacles + gameManager.speedMovement;

        //Movement z of the obstacle with the inital speed of the obstacle 
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z + initialSpeedObstacles);


    }
}
