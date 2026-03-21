using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float startBulletSpeed;
    private float bulletSpeed;
    public float maxBulletSpeed;
    public float acceleration;

    private Rigidbody2D rb;

    private void Start()
    {
        bulletSpeed = startBulletSpeed;
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 10);
    }

    private void FixedUpdate()
    {
        bulletSpeed = Mathf.Lerp(bulletSpeed, maxBulletSpeed, Time.deltaTime * acceleration);
        rb.linearVelocity = Vector2.up * bulletSpeed;

        //Debug.Log(rb.linearVelocity.magnitude);
    }
}
