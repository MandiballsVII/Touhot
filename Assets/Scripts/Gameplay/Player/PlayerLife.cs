using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public float playerMaxHealth;
    
    private float playerHealthPoints;

    private void Start()
    {
        playerHealthPoints = playerMaxHealth;
    }

    public void DealDamageToPlayer(float damage)
    {
        playerHealthPoints -= damage;

        if(playerHealthPoints > 0)
        {
            playerHealthPoints = 0;
        }
    }

    public void HealPlayer(float heal)
    {
        playerHealthPoints += heal;

        if(playerHealthPoints < playerMaxHealth)
        {
            playerHealthPoints = playerMaxHealth;
        }
    }
}
