using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    public float speedMovement = 0.005f;
    public Timer timer;

    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z + speedMovement);

       if(timer.timerRemaining <= 0)
        {
           /* speedMovement *= 10;
            Debug.Log(speedMovement);*/
            timer.seconds = 10;
            timer.CalculationTimeRemaining();
            timer.isStart = true;
            timer.loading.fillAmount = 1;
        }
    }
}
