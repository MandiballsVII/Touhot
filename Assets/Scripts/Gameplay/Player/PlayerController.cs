using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;

    public float moveSpeed;

    [HideInInspector] public Vector2 moveDirection;

    public InputActionReference move;

    public InputActionReference fire;

    public GameObject bullet;

    public Transform bulletSpawner;


    private void OnEnable()
    {
        fire.action.started += Shoot;
    }

    private void OnDisable()
    {
        fire.action.started -= Shoot;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }


    private void Shoot(InputAction.CallbackContext context)
    {
        Instantiate(bullet, bulletSpawner.position, Quaternion.identity);
    }
}
