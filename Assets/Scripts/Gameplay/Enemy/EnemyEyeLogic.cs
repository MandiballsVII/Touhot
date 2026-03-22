using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyEyeLogic : MonoBehaviour
{
    public float MaxHealth;
    private float currentHealth;
    public bool isBroken = false;
    public EnemyInfo fullEnemy;
    private SpriteRenderer spriteRenderer;
    public RadialShotWeapon eyeWeapon;

    private Animator animator;

    private void Start()
    {
        currentHealth = MaxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        if(!isBroken)
        {
            currentHealth -= amount;
            animator.SetTrigger("eyeHit");
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isBroken = true;
                animator.SetBool("isBroken", true);
                GetComponentInChildren<RadialShotWeapon>().StopAllCoroutines();
                eyeWeapon.shotPattern = GameManager.instance.patterns[4];
                GetComponentInChildren<RadialShotWeapon>().onShotPattern = false;
                AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.EyeDestroyed, transform.position);
            }
            else
            {
                AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.Impact, transform.position);
            }
            fullEnemy.CheckVulnerableStatus();
        }
        else
        {
            AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.EnemyInvulnerable, transform.position);
        }
    }
}
