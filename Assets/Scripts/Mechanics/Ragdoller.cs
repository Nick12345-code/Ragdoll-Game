using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoller : MonoBehaviour
{
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
        DisableRagdoll();
    }

    private void Update()
    {
        if (startingPosition != transform.position)
        {
            EnableRagdoll();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Ball"))
        {
            EnableRagdoll();
        }
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
