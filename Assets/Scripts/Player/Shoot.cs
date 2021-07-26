using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Bullet bulletScript;
    [Header("Setup")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Slider powerSlider;
    public int bulletCount;
    [Header("Bullet Speed")]
    public float mass;
    public float minMass;
    public float maxMass;
    public float massMultiplier;

    private void Start()
    {
        powerSlider.value = 0;
        powerSlider.maxValue = maxMass;
        powerSlider.minValue = minMass;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (bulletCount == 0)
            {
                if (mass > maxMass)
                {
                    mass = maxMass;
                }
                else
                {
                    mass = mass += massMultiplier * Time.deltaTime;
                    powerSlider.value = mass;
                }
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
        GameObject a = Instantiate(bullet, firePoint.position, firePoint.rotation) as GameObject;
        a.transform.SetParent(GameObject.Find("Clones").transform);
        bulletCount = 1;
    }
}
