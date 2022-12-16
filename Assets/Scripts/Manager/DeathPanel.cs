using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{
    public Text scoreTxt;
    public ScoreManager scoreManager;
    public int finalScore = 0;

    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();

        scoreTxt.text = "Score: " + scoreManager.score.ToString();
    }
    public void BackToTheMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
