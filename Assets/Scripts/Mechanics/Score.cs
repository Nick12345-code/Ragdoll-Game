using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public HoleTrigger holeTrigger;
    [Header("Score")]
    [SerializeField] private int score;
    [SerializeField] private Text scoreText;
    [SerializeField] private bool scoreUpdated;
    [Header("Shots")]
    [SerializeField] private int shots;
    [SerializeField] private Text shotsText;
    [Header("Timer")]
    [SerializeField] private float time;
    [SerializeField] private float timeLost;
    [SerializeField] private Text timeText;

    private void Update()
    {
        UpdateTime();

        if (holeTrigger.scored == true)
        {
            if (scoreUpdated == false)
            {
                UpdateScore((int)time);
                UpdateScore(10);
                UpdateScore(-shots);
                scoreUpdated = true;
            }
        }
    }

    // updates how many shots the player has taken
    public void UpdateShots(int amount)
    {
        shots += amount;
        shotsText.text = shots.ToString() + " Shots";
    }

    // updates the count down timer
    private void UpdateTime()
    {
        time = timeLost -= Time.deltaTime;
        timeText.text = time.ToString("0");
    }

    // updates the score the player has earned
    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "You achieved a score of " + score.ToString();
    }
}
