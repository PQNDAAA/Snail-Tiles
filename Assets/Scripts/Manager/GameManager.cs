using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ProceduralGeneration proceduralGeneration;
    public Timer timer;
    public ScoreManager scoreManager;
    public PlayerController playerController;
    public GameObject deathPanel;
    public TextMeshProUGUI waveTxt;

    //calculate the speed movement of obstacles 
    public float speedMovement;
    //max speed movement added for an obstacle
    public float maxSpeedMovement = 0.03f;

    public int eventMade = 0;

    public bool isDead = false;

    void Start()
    {
        proceduralGeneration = GameObject.Find("ProceduralGeneration").GetComponent<ProceduralGeneration>();
        playerController = FindObjectOfType<PlayerController>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();

        scoreManager = GetComponent<ScoreManager>();
    }

    void Update()
    {
        CheckDistance();
        CheckTimer();
        CheckPlayer();

        AccelerateGame();
    }
    //The game destroy obstacles if their distances z is 25
    public void CheckDistance()
    {
        foreach(GameObject go in FindObstacles())
        {
            if(go.transform.position.z >= 25)
            {
                Destroy(go);
            }
        }
    }
    //The game checks if the timer finished to accelerate the obstacles and increase the score
    public void CheckTimer()
    {
        if(timer.timerRemaining <= 0)
        {
            if (speedMovement <= maxSpeedMovement)
            {
                speedMovement += Time.deltaTime;
                playerController.lerpDuration /= 1.23f;
            }

            scoreManager.AddMultiplier(1);
            timer.RestartTimer(10);

            eventMade += 1;
            waveTxt.text = "Event "+eventMade;
        }
    }
    //The game checks if the player died or not 
    public bool CheckPlayer()
    {
        if (FindPlayer() == null)
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0;
            return isDead = true;
        }
        else
        {
            return isDead = false;
        }
    }

    //The game accelerates when a event made number is crossed
    public void AccelerateGame()
    {
        if (FindObstacles().Length == 0) 
        {
            if (eventMade >= 5 && eventMade < 10)
            {
                StartCoroutine(proceduralGeneration.SpawnObstacles(2));
            }
            else if (eventMade >= 10 && eventMade < 50)
            {
                StartCoroutine(proceduralGeneration.SpawnObstacles(3));
            }
            else if(eventMade >= 50)
            {
                StartCoroutine(proceduralGeneration.SpawnObstacles(4));
            }
            else
            {
                StartCoroutine(proceduralGeneration.SpawnObstacles(1));
            }
        }
    }

    //The game finds various Go
    public GameObject[] FindObstacles()
    {
        return GameObject.FindGameObjectsWithTag("Obstacles");
    }
    public GameObject FindPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }
}
