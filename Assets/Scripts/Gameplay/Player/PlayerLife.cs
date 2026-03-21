using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    public float playerMaxHealth;
    public TMP_Text playerLifeText;
    
    private float playerHealthPoints;

    private void Start()
    {
        playerHealthPoints = playerMaxHealth;
        UpdatePlayerHP_Text();
    }

    public void DealDamageToPlayer(float damage)
    {
        playerHealthPoints -= damage;

        if(playerHealthPoints < 0)
        {
            playerHealthPoints = 0;

        }
        UpdatePlayerHP_Text();
    }

    public void HealPlayer(float heal)
    {
        playerHealthPoints += heal;

        if(playerHealthPoints > playerMaxHealth)
        {
            playerHealthPoints = playerMaxHealth;
        }
        UpdatePlayerHP_Text();
    }

    private void UpdatePlayerHP_Text()
    {
        playerLifeText.text = ("Player HP: " + playerHealthPoints);
    }
}
