using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int shots;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text shotsText;

    public void UpdateShotsText(int amount)
    {
        shots += amount;
        shotsText.text = shots.ToString() + " Shots";
    }

    public void UpdateScoreText(int amount)
    {
        score += amount;
        scoreText.text = score.ToString() + " Score";
    }
}
