using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    float score = 0;
    float multiplicater = 1;

    float shakeMultiplierStrenght = 0.01f;


    public TextMeshProUGUI UI_score;
    public TextMeshProUGUI UI_Multiplier;

    // Update is called once per frame
    void Update()
    {
        score += 0.001f * multiplicater;
        UI_score.text = Mathf.Round(score).ToString();
        UI_Multiplier.text = multiplicater.ToString("F2");

        shakeMultiplierStrenght = multiplicater / 200;
        UI_Multiplier.transform.position = new Vector2(UI_Multiplier.transform.position.x + (shakeMultiplierStrenght * Mathf.Cos(multiplicater * Time.time)),
            UI_Multiplier.transform.position.y + shakeMultiplierStrenght * Mathf.Cos(multiplicater * Time.time));
    }

    public void AddMultiplier(float value)
    {
        multiplicater += value;
    }




}
