using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    AbstractObstacles obstacles;

    public Timer timer;

    void Start()
    {
        obstacles = GetComponent<AbstractObstacles>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }
    void Update()
    {
    }
}
