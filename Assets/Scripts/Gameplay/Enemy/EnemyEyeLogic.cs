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
            }
            fullEnemy.CheckVulnerableStatus();
        }
    }
}
