using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public Score scoreScript;
    public PlayerController controller;
    public bool scored;
    [SerializeField] private GameObject results;

    private void Start()
    {
        results.SetActive(false);
    }

    // if player hasn't scored yet, and an object tagged 'Ragdoll' collides with this, then player scores
    private void OnCollisionEnter(Collision collision)
    {
        if (scored == false)
        {
            if (collision.gameObject.GetComponent<Collider>().CompareTag("Ragdoll"))
            {
                ShowResults();
            } 
        }
    }

    // shows the results screen
    private void ShowResults()
    {
        controller.CanMove = false;
        scored = true;
        results.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
