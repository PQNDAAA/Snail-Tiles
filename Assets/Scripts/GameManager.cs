using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ProceduralGeneration proceduralGeneration;
    public Timer timer;

    public float speedMovement;

    void Start()
    {
        proceduralGeneration = GameObject.Find("ProceduralGeneration").GetComponent<ProceduralGeneration>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    void Update()
    {
        CheckDistance();
        CheckObstacles();
        CheckTimer();

        
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
    public void CheckTimer()
    {
        if(timer.timerRemaining <= 0)
        {
            speedMovement += Time.deltaTime;

            timer.seconds = 10;
            timer.CalculationTimeRemaining();
            timer.isStart = true;
            timer.loading.fillAmount = 1;
        }
    }

    public GameObject[] FindObstacles()
    {
        return GameObject.FindGameObjectsWithTag("Obstacles");
    }
}
