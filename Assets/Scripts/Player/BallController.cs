using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Score score;
    [Header("Picking Up and Throwing")]
    [SerializeField] private GameObject ball;           // the ball ...
    [SerializeField] private Camera playerCamera;       // player's perspective
    [SerializeField] private Slider powerSlider;
    [SerializeField] private bool holdingBall;          // whether ball is being held or not
    [SerializeField] private float ballDistance;        // starting position of ball
    [SerializeField] private float reachDistance;       // how far the player can pick the ball up from
    [Header("Throw Power")]
    [SerializeField] private float power;               // how powwerful the throw is
    [SerializeField] private float minPower;            // minimum throw power
    [SerializeField] private float maxPower;            // maximum throw power
    [SerializeField] private float powerMultiplier;     // how fast power is charged up

    private void Start()
    {
        ball.GetComponent<Rigidbody>().useGravity = false;
        powerSlider.value = 0;
        powerSlider.maxValue = maxPower;
        powerSlider.minValue = minPower;
    }

    private void Update()
    {
        PickUpBall();
        ChargeUp();
        ThrowBall();
    }

    private void PickUpBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, reachDistance))
            {
                if (hit.collider.CompareTag("Ball"))
                {
                    holdingBall = true;
                    ball.GetComponent<Rigidbody>().useGravity = false;
                    power = minPower;
                }
            } 
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            holdingBall = true;
            ball.GetComponent<Rigidbody>().useGravity = false;
            power = minPower;
        }
    }

    private void ChargeUp()
    {
        if (Input.GetButton("Jump") && holdingBall)
        {
            if (power > maxPower)
            {
                power = maxPower;
            }
            else
            {
                power = power += powerMultiplier * Time.deltaTime;
                powerSlider.value = power;
            }
        }
    }

    private void ThrowBall()
    {
        if (holdingBall)
        {
            ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;

            if (Input.GetMouseButtonDown(1))
            {
                holdingBall = false;
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * power, ForceMode.Impulse);            
                score.UpdateShots(1);
            }
        }
    }
}
