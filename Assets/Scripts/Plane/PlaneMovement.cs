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


    private float maxSpeedValue = 30f;
    private float aceleration = 9f;
    private float deceleration = 7.5f;

    private float newSpeed;

    private void Start()
    {
        RestartValues();
    }
    public void RestartValues()
    {
        QualitySettings.vSyncCount = 0;
        int targetFrameRate = 60;
        Application.targetFrameRate = targetFrameRate;
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
        #region EVERYTHING ELSE
        if (!Application.platform.Equals(RuntimePlatform.Android))
        {
            if (GameController.Instance.CanPlay && !slowing)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    currentSpeed = SpeedChanger(_speedChangerAmount);
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    currentSpeed = SpeedChanger(-_speedChangerAmount);
                }
            }
        }
        #endregion
        #region Android
        else
        {
            if (GameController.Instance.CanPlay && !slowing)
            {
                currentSpeed = SpeedChanger(_speedChangerAmount * (fixedJoystick.Vertical*0.75f));
            }
        }
        #endregion

        planeSpeed = currentSpeed;
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

        transform.Translate(Vector3.back * currentSpeed * 2f * Time.deltaTime);

        return currentSpeed;
    }

    public void RestartLevel()
    {
        planeSpeed = 0f;
        this.transform.position = Vector3.zero;
    }
}
