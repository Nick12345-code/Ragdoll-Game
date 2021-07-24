using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public Score scoreScript;
    public bool levelCompleted;
    [SerializeField] private GameObject results;

    private void Start()
    {
        results.SetActive(false);
    }

    private void Update()
    {
        // if there are no ragdolls left, the player has completed the level
        if (GameObject.FindWithTag("Ragdoll") == null)
        {
            ShowResults();
        }
    }

    // shows the results screen
    private void ShowResults()
    {
        levelCompleted = true;
        results.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
