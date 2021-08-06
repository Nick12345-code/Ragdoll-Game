using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Score score;
    [Header("Setup")]
    [SerializeField] private GameObject ball;           // the ball ...
    [SerializeField] private Camera playerCamera;       // player's perspective
    [SerializeField] private Slider powerBar;           // represents how powerful each throw will be
    [SerializeField] private bool holdingBall;          // whether ball is being held or not
    [SerializeField] private bool chargingUp;           // whether throw is charging up
    [SerializeField] private float startPos;            // starting position of ball
    [SerializeField] private float returnTime;          // time until ball is returned to the player
    [Header("Throw Power")]
    [SerializeField] private float power;               // how powwerful the throw is
    [SerializeField] private float minPower;            // minimum throw power
    [SerializeField] private float maxPower;            // maximum throw power
    [SerializeField] private float powerMultiplier;     // how fast power is charged up

    private void Start()
    {
        ball.GetComponent<Rigidbody>().useGravity = false;
        // power slider setup
        powerBar.value = 0;
        powerBar.maxValue = maxPower;
        powerBar.minValue = minPower;
    }

    private void Update()
    {
        ChargeUp();
        ThrowBall();
    }

    // charging up the power in order to throw the ball further
    private void ChargeUp()
    {
        // if space bar is held down and the ball is being held
        if (Input.GetKey(KeyCode.Space) && holdingBall)
        {
            chargingUp = true;

            // power can't go beyond max power
            if (power > maxPower)
            {
                power = maxPower;
            }
            else
            {
                // power slowly increases
                power = power += powerMultiplier * Time.deltaTime;
                powerBar.value = power;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            chargingUp = false;
        }
    }

    // throwing the ball
    private void ThrowBall()
    {
        // if ball is held
        if (holdingBall)
        {
            // ball is repositioned
            ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * startPos;

            // if left mouse button is clicked
            if (Input.GetMouseButtonDown(0) && !chargingUp)
            {
                holdingBall = false;
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * power, ForceMode.Impulse);            
                score.UpdateShots(1);
                Invoke("ReturnBall", returnTime);
            }
        }
    }

    // ball returns to player by default after a few seconds
    private void ReturnBall()
    {
        holdingBall = true;
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        power = minPower;
        powerBar.value = power;
    }
}
