using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float oxygen;
    public float fuel;

    public float oxygenDecreaseRate = 1.5f;
    public float fuelDecreaseRate = 0.5f;
    public float deAccelerationRate = 5f;

    public float currentSpeed = 0f;

    public bool moving=false;
    private bool isPlaneMoving;
    private float oxygenOriginalValue;
    private float fuelOriginalValue;
    private Image gasMeter;
    private Image oxygenMeter;
    private float planeCurrentSpeedReducer = 0.025f;

    private void Start()
    {
        oxygenOriginalValue = 100f;
        fuelOriginalValue = 100f;
        moving = false;
        gasMeter = GameObject.Find("GasImageBar").GetComponent<Image>();
        oxygenMeter = GameObject.Find("OxygenImageBar").GetComponent<Image>();
    }

    public void RestartValues()
    {
        oxygen = 100f;
        fuel = 100f;
    }

    private void LateUpdate()
    {
        if (GameController.Instance.CanPlay)
        {
            DecreaseOxygen();

            DecreaseFuel();
        }
    }

    private void DecreaseOxygen()
    {
        oxygen -= oxygenDecreaseRate * Time.deltaTime;

        oxygen = Mathf.Clamp(oxygen , 0f, oxygenOriginalValue);

        oxygenMeter.fillAmount = oxygen / 100f;

        if (oxygen <= 0f)
        {
            GameController.Instance.PlayerDied(this.gameObject, false);
        }
    }

    public void DecreaseFuel()
    {
        if (PlaneMovement.planeMoving)
        {

            fuel -= fuelDecreaseRate * Time.deltaTime * (PlaneMovement.currentSpeed * planeCurrentSpeedReducer);

            fuel = Mathf.Clamp(fuel,0f,fuelOriginalValue);

            if (fuel <= 0)
            {
                PlaneMovement.slowing = true;
                PlaneMovement.planeSpeed = Deaccelerate();
            }

            if (PlaneMovement.planeSpeed <= 0)
            {
                PlaneMovement.planeSpeed = 0;
                currentSpeed = PlaneMovement.planeSpeed;
                GameController.Instance.LostState();
            }

            gasMeter.fillAmount = fuel / 100f;
        }
    }

    public float Deaccelerate()
    {
        float newSpeed = Mathf.Max(0f, currentSpeed - deAccelerationRate * Time.deltaTime);

        return newSpeed;
    }
}
