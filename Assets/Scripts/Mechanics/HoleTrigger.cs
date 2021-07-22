using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public Score scoreScript;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Collider>().CompareTag("Ragdoll"))
        {
            scoreScript.UpdateScoreText(5);
            print("You scored!");
        }
    }
}
