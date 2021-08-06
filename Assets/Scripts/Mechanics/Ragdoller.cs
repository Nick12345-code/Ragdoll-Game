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
        // if ragdoll moves, enable ragdoll
        if (startingPosition != transform.position)
        {
            EnableRagdoll();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if ragdoll is hit by ball, enable ragdoll
        if (other.GetComponent<Collider>().CompareTag("Ball"))
        {
            EnableRagdoll();
        }
    }

    void EnableRagdoll()
    {
        // gets all the rigidbodies within the ragdoll
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();

        // for each rigidbody make in kinematic (movable)
        foreach (var body in bodies)
        {
            body.isKinematic = false;
        }
    }

    void DisableRagdoll()
    {
        // gets all the rigidbodies within the ragdoll
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();

        // for each rigidbody make in non-kinematic (immovable)
        foreach (var body in bodies)
        {
            body.isKinematic = true;
        }
    }
}
