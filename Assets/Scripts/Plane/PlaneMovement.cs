using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick fixedJoystick;

    private float _speedChangerAmount;

    public static bool planeMoving;

    public static float currentSpeed;

    public static bool slowing;

    public static float planeSpeed;

    private ParticleSystem particleEmission;

    private float particleMultiplier = 0.1f;

    public static bool _maxSpeed = false;


    private float maxSpeedValue = 25f;
    private float aceleration = 7.5f;
    private float deceleration = 7.5f;

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
        #region ANDROID
        if (Application.platform.Equals(RuntimePlatform.Android))
        {
            if (GameController.Instance.CanPlay && !slowing)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    planeSpeed = SpeedChanger(_speedChangerAmount);
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    planeSpeed = SpeedChanger(-_speedChangerAmount);
                }
            }
        }
        #endregion
        #region EVERYTHING ELSE
        else
        {
            if (GameController.Instance.CanPlay && !slowing)
            {
                planeSpeed = SpeedChanger(_speedChangerAmount * (fixedJoystick.Vertical*0.5f));
            }
        }
        #endregion
    }

    private float SpeedChanger(float speedChanger)
    {

        if (speedChanger > 0)
        {
            planeSpeed = Mathf.MoveTowards(planeSpeed, maxSpeedValue, aceleration * Time.deltaTime);
        }


        if (speedChanger <= 0)
        {
            planeSpeed = Mathf.MoveTowards(planeSpeed, 0f, deceleration * Time.deltaTime);
        }

        if (planeSpeed <=0)
        {
            planeSpeed = 0;
        }

        if (planeSpeed >= maxSpeedValue)
        {
            planeSpeed = maxSpeedValue;
        }

        currentSpeed = planeSpeed;

        Debug.Log(currentSpeed);

        transform.Translate(Vector3.back * planeSpeed * Time.fixedDeltaTime);

        return currentSpeed;
    }
}
