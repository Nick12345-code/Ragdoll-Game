using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] Vector3 pointA = new Vector3(0, 0, 0);
    [SerializeField] Vector3 pointB = new Vector3(1, 1, 1);

    private void Update()
    {
        // smoothly moves object between 2 points
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }
}
