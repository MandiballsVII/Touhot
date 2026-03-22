using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float startBulletSpeed;
    private float bulletSpeed;
    public float maxBulletSpeed;
    public float acceleration;
    public float bulletDamage;

    public GameObject impact;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if(collision.GetComponent<EnemyLife>().vulnerable)
            {
                collision.gameObject.GetComponent<EnemyLife>().DealDamageToEnemy(bulletDamage);
            }
            else
            {
                AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.EnemyInvulnerable, transform.position);
            }
                Instantiate(impact, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }else if(collision.tag == "EnemyEye")
        {
            collision.gameObject.GetComponent<EnemyEyeLogic>().TakeDamage(bulletDamage);
            Instantiate(impact, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
