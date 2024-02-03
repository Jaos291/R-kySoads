using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 8.5f;
    public float jumpForce = 5f;
    public float toRotate = 25.55f;
    private Rigidbody _rb;

    private float x;

    private float rotationTime = 0.125f;

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
    }
    private void Update()
    {
        if (GameController.Instance.CanPlay)
        {
            LeanTween.rotateY(this.gameObject, 0f, 0f);
            Move();
            Jump();
            var emission = exhaustParticleSystem.emission;
            emission.rateOverTime = PlaneMovement.planeSpeed * exhaustParticleSystemMultiplier;
            for (int i = 0; i < hyperSpeedParticleSystem.Length; i++)
            {
                var hyperSpeedEmission = hyperSpeedParticleSystem[i].emission;
                hyperSpeedEmission.rateOverTime = PlaneMovement.planeSpeed * hyperSpeedParticleSystemMultiplier;
            }
        }
    }

    private void Move()
    {
        x = Input.GetAxis("Horizontal");
        if (x > 0)
        {
            LeanTween.rotateZ(this.gameObject, -10f, 0.125f);
        }
        else if (x < 0)
        {
            LeanTween.rotateZ(this.gameObject, 10f, 0.125f);
        }
        else
        {
            LeanTween.rotateZ(this.gameObject,0f,0.125f);
        }
        _rb.velocity = new Vector2(playerSpeed * x, _rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            _rb.AddForce(new Vector2(_rb.velocity.x, jumpForce), ForceMode.Impulse);

            if (_rb.velocity.y<0)
            {
                _isFalling = true;
            }

            StartRotation();
        }
    }

    private void StartRotation()
    {
        LeanTween.rotateX(this.gameObject, -17.5f, 0.125f).setOnComplete(finishRotation);
    }

    private void finishRotation()
    {
        if (_isFalling)
        {
            LeanTween.rotateX(this.gameObject, 17.5f, 0.50f);
        }
    }
}
