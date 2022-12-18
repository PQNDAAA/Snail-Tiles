using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public float multiplier = 1;

    //Shake float
    float shakeMultiplierStrenght = 0.01f;

    //UI
    public TextMeshProUGUI UI_score;
    public TextMeshProUGUI UI_Multiplier;

    public GameManager gameManager;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        //Stop the score when the player died
        if (gameManager.isDead == false)
        {
            score += 0.001f * multiplier;
            Debug.Log(gameManager.isDead);

            shakeMultiplierStrenght = multiplier / 200;
        }

        //Shake the multiplier when I increase more and more
        UI_Multiplier.transform.position = new Vector2(UI_Multiplier.transform.position.x + (shakeMultiplierStrenght * Mathf.Cos(multiplier * Time.time)),
            UI_Multiplier.transform.position.y + shakeMultiplierStrenght * Mathf.Cos(multiplier * Time.time));

        //UI
        UI_score.text = Mathf.Round(score).ToString();
        UI_Multiplier.text = multiplier.ToString("F2");
    }
    //Increase the multiplier
    public void AddMultiplier(float value)
    {
        multiplier += value;
    }
}
