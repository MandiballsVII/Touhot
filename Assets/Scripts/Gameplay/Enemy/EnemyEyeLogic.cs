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

    private void Start()
    {
        currentHealth = MaxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float amount)
    {
        if(!isBroken)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isBroken = true;
                spriteRenderer.color = Color.black;
                GetComponentInChildren<RadialShotWeapon>().StopAllCoroutines();
                eyeWeapon.shotPattern = GameManager.instance.patterns[4];
                GetComponentInChildren<RadialShotWeapon>().onShotPattern = false;
            }
            fullEnemy.CheckVulnerableStatus();
        }
    }
}
