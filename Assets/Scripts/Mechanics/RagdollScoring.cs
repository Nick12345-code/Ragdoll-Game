using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollScoring : MonoBehaviour
{
    private Joint[] joints;
    [SerializeField] private float currentScore;
    [SerializeField] private float minForceToAddScore;

    private void FixedUpdate()
    {
        currentScore += ScoreRagdoll();
    }

    private void OnEnable()
    {
        joints = GetComponentsInChildren<Joint>();
    }

    private float ScoreRagdoll()
    {
        float totalForce = 0f;

        foreach (var joint in joints)
        {
            if (joint.currentForce.magnitude > minForceToAddScore)
            {
                totalForce += joint.currentForce.magnitude; 
            }
        }
        return totalForce;
    }
}
