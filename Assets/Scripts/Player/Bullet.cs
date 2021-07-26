using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Shoot shoot;
    private Transform firePoint;
    private Rigidbody rb;
    [SerializeField] private float maxDistance;
    [SerializeField] private float speed;

    private void Start()
    {
        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        shoot = GameObject.Find("Shoot").GetComponent<Shoot>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // if distance between the fire point and the bullet is greater than specified, the bullet will be destroyed (else bullet keeps moving forward)
        if (Vector3.Distance(firePoint.position, transform.position) > maxDistance)
        {
            Destroy(this.gameObject);
            shoot.bulletCount = 0;
            shoot.mass = shoot.minMass;
        }
        else
        {
            rb.AddForce(transform.forward * speed);
            rb.mass = shoot.mass;
        }
    }
}
