using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 8.5f;
    public float jumpForce = 5f;
    public float toRotate = 25.55f;
    
    private Rigidbody _rb;
    private Joystick fixedJoystick;
    
    private float x;
    
    [HideInInspector] public bool canJump = true;
    [HideInInspector] public bool isRotating = false;
    [HideInInspector] public bool _isFalling = false;
    
    public ParticleSystem exhaustParticleSystem;
    public ParticleSystem[] hyperSpeedParticleSystem;
    
    private float exhaustParticleSystemMultiplier = 1.75f;
    private float hyperSpeedParticleSystemMultiplier = 0.3f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector2(0, -9.8f) * GameController.Instance.StageConfigurationSO.gravityScale;

        if (Application.platform == RuntimePlatform.Android)
        {
            fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
        }
        
    }

    private void Update()
    {
        if (!GameController.Instance.CanPlay)
        {
            return;
        }

        LeanTween.rotateY(gameObject, 0f, 0f);
        Move();

        if (Application.platform != RuntimePlatform.Android)
        {
            PCJump();
        }

        UpdateExhaustParticleSystem();
        UpdateHyperSpeedParticleSystem();
    }

    private void UpdateExhaustParticleSystem()
    {
        var emission = exhaustParticleSystem.emission;
        emission.rateOverTime = PlaneMovement.planeSpeed * exhaustParticleSystemMultiplier;
    }

    private void UpdateHyperSpeedParticleSystem()
    {
        foreach (var particleSystem in hyperSpeedParticleSystem)
        {
            var hyperSpeedEmission = particleSystem.emission;
            hyperSpeedEmission.rateOverTime = PlaneMovement.planeSpeed * hyperSpeedParticleSystemMultiplier;
        }
    }

    private void PCJump()
    {
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            _rb.AddForce(new Vector2(_rb.velocity.x, jumpForce), ForceMode.Impulse);

            if (_rb.velocity.y < 0)
            {
                _isFalling = true;
            }

            StartRotation();
        }
    }

    private void Move()
    {
        x = Application.platform.Equals(RuntimePlatform.Android) ? fixedJoystick.Horizontal : Input.GetAxis("Horizontal");

        LeanTween.rotateZ(gameObject, x > 0 ? -10f : (x < 0 ? 10f : 0f), 0.125f);
        _rb.velocity = new Vector2(playerSpeed * x, _rb.velocity.y);
    }

    public void Jump()
    {
        if (canJump)
        {
            canJump = false;
            _rb.AddForce(new Vector2(_rb.velocity.x, jumpForce), ForceMode.Impulse);

            if (_rb.velocity.y < 0)
            {
                _isFalling = true;
            }

            StartRotation();
        }
    }

    private void StartRotation()
    {
        LeanTween.rotateX(gameObject, -17.5f, 0.125f).setOnComplete(FinishRotation);
    }

    private void FinishRotation()
    {
        if (_isFalling)
        {
            LeanTween.rotateX(gameObject, 17.5f, 0.50f);
        }
    }
}
