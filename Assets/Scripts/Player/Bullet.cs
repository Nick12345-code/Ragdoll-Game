using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float maxDistance;
    [SerializeField] private GameObject player;

    private void Start()
    {
        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        player = GameObject.Find("PlayerController");
    }

    private void Update()
    {
        // if distance between the fire point and the bullet is greater than specified, the bullet will be destroyed (else bullet keeps moving forward)
        if (Vector3.Distance(firePoint.position, transform.position) > maxDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
