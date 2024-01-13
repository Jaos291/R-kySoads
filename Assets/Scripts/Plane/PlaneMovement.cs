using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneMovement : MonoBehaviour
{
    

    [SerializeField] private float _speedChangerAmount = 2f;

    public static bool planeMoving;

    public static float currentSpeed;

    public static bool slowing;

    public static float planeSpeed;

    private void Start()
    {
        RestartValues();
    }
    public void RestartValues()
    {
        planeMoving = false;
        currentSpeed = 0;
        slowing = false;
        planeSpeed = 0;
    }

    private void Update()
    {
        if (GameController.Instance.CanPlay)
        {
            transform.Translate(Vector3.back * planeSpeed * Time.fixedDeltaTime);

            ChangeSetSpeed();

            if (planeSpeed > 0)
            {
                planeMoving = true;
            }
            else
            {
                planeMoving = false;
            }
        }
    }

    public void ChangeSetSpeed()
    {
        if (!Application.platform.Equals(RuntimePlatform.Android))
        {
            if (GameController.Instance.CanPlay && !slowing)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    MoreSpeed(_speedChangerAmount);
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    LessSpeed(_speedChangerAmount);
                }
            }
        }
    }

    public void MoreSpeed(float speedChanger)
    {
        planeSpeed += speedChanger;
        currentSpeed = planeSpeed;
        Debug.Log(planeSpeed);
    }

    public void LessSpeed(float speedChanger)
    {
        planeSpeed -= speedChanger;

        if (planeSpeed <= 0)
        {
            planeSpeed = 0;
        }
        currentSpeed = planeSpeed;
    }
}
