using System;
using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;

public class PlayerController: MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;

    public float moveSpeed;

    [HideInInspector] public Vector2 moveDirection;

    public InputActionReference move;

    public InputActionReference fire;

    public GameObject bullet;

    public Transform bulletSpawner;

    private EventInstance shipEngineInstance;


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
        shipEngineInstance = AudioManager.Instance.CreateEventInstance(FMOD_Events.Instance.ShipEngine);
    }

    private void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        UpdateSound();
    }


    private void Shoot(InputAction.CallbackContext context)
    {
        Instantiate(bullet, bulletSpawner.position, Quaternion.identity);
        AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.PlayerShoot, transform.position);
    }

    private void UpdateSound()
    {
        if (rb.linearVelocityX != 0 || rb.linearVelocityY != 0)
        {
            PLAYBACK_STATE playbackState;
            shipEngineInstance.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                shipEngineInstance.start();
            }
        }
        else
        {
            shipEngineInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    } 
}
