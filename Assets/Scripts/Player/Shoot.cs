using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Bullet bulletScript;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    public float speed;
    public int bulletCount;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (bulletCount == 0)
            {             
                speed = speed += Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (bulletCount == 0)
            {
                SpawnBullet();
            }
        }
    }

    private void SpawnBullet()
    {
        print("You shot a bullet!");
        GameObject a = Instantiate(bullet, firePoint.position, firePoint.rotation) as GameObject;
        a.transform.SetParent(GameObject.Find("Clones").transform);
        bulletCount = 1;
    }
}
