using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRagdoll : MonoBehaviour
{
    [SerializeField] private ParticleSystem ragdollDeathEffect;
    // if ragdoll touches the ground it is destroyed (code looks funny since a toe could touch the ground first so I have to destroy the top most parent)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ragdoll"))
        {
            Destroy(collision.transform.parent.parent.parent.parent.gameObject);
        }
    }
}
