using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneMovement : MonoBehaviour
{

    private float _speedChangerAmount;

    public static bool planeMoving;

    public static float currentSpeed;

    public static bool slowing;

    public static float planeSpeed;

    private ParticleSystem particleEmission;

    private float particleMultiplier = 0.1f;

    public static bool _maxSpeed = false;

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
        _speedChangerAmount = GameController.Instance.StageConfigurationSO.speedMultiplier;
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
        if (planeSpeed >= 25)
        {
            planeSpeed = 25;
            _maxSpeed = true;
        }
        else
        {
            _maxSpeed = false;
        }
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
