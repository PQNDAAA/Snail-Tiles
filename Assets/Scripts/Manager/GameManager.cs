using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ProceduralGeneration proceduralGeneration;
    public Timer timer;
    public ScoreManager scoreManager;
    public PlayerController playerController;
    public GameObject deathPanel;

    public float speedMovement;
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
        CheckObstacles();
        CheckTimer();
        CheckPlayer();
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

            playerController.lerpDuration /= 1.23f;

            scoreManager.AddMultiplier(1);
            timer.RestartTimer(10);

            eventMade += 1;
        }
    }
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

    public GameObject[] FindObstacles()
    {
        return GameObject.FindGameObjectsWithTag("Obstacles");
    }
    public GameObject FindPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }
}
