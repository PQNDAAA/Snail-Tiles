using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractObstacles : MonoBehaviour
{
    public float speedObstacles;
    public float maxSpeedObstacles;

    public GameManager gameManager;
    abstract public void Update();

    //abstract public void UpdateMovement();


}
