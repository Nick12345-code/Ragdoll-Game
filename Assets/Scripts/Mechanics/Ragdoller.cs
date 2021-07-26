using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoller : MonoBehaviour
{
    private void OnEnable()
    {
        DisableRagdoll();
    }

    private void Update()
    {
        
    }

    void EnableRagdoll()
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();

        foreach (var body in bodies)
        {
            body.isKinematic = false;
        }
    }

    void DisableRagdoll()
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();

        foreach (var body in bodies)
        {
            body.isKinematic = true;
        }
    }
}
