using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 8.5f;
    public float jumpForce = 5f;
    public float toRotate = 7.5f;
    private Rigidbody _rb;

    private float x;

    private float rotationTime = 0.5f;

    [HideInInspector] public bool isGrounded = true;

    [HideInInspector] public bool isRotating = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector2(0, -9.8f) * GameController.Instance.StageConfigurationSO.gravityScale;
    }
    private void Update()
    {
        if (GameController.Instance.CanPlay)
        {
            Move();
            Jump();
        }
    }

    private void Move()
    {
        x = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(playerSpeed * x, _rb.velocity.y);
        if (isGrounded)
        {
            LeanTween.rotate(this.gameObject, new Vector3(0, 0), 0.25f);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            _rb.AddForce(new Vector2(_rb.velocity.x, jumpForce), ForceMode.Impulse);
            LeanTween.rotate(this.gameObject, new Vector3(toRotate, this.gameObject.transform.rotation.y), rotationTime);
        }
    }
}
