using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractObstacles : MonoBehaviour
{
    public float defautSpeedObstacles;
    //Initial speed calculated by the defaut speed and the speed movement 
    //Speed movement in GameManager.cs is calculated += "Time.deltatime"
    public float initialSpeedObstacles;

    public GameManager gameManager;
    abstract public void Update();


}
