using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollScoring : MonoBehaviour
{
    [Header("References")]
    public Score scoreScript;
    [Header("Setup")]
    private Joint[] joints;
    [SerializeField] private float currentScore;
    [SerializeField] private float minForceToAddScore;

    // score is updated frequently at a fixed rate
    private void FixedUpdate()
    {
        currentScore += ScoreRagdoll();
        scoreScript.UpdateScore((int)currentScore / 1000);
    }

    // gets the joints from the ragdolls immediately
    private void OnEnable()
    {
        joints = GetComponentsInChildren<Joint>();
    }

    private float ScoreRagdoll()
    {
        float totalForce = 0f;

        // for each joint in joints
        foreach (var joint in joints)
        {
            // if the force applied is larger than the minimum requirement
            if (joint.currentForce.magnitude > minForceToAddScore)
            {
                // total force equals the force that was applied
                totalForce += joint.currentForce.magnitude; 
            }
        }
        // get the total force applied
        return totalForce;
    }
}
