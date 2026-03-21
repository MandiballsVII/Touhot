using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float playerMaxHealth;
    public Slider playerLifeSlider;
    
    private float playerHealthPoints;

    private void Start()
    {
        playerHealthPoints = playerMaxHealth;
        UpdatePlayerHP_Slider();
    }

    public void DealDamageToPlayer(float damage)
    {
        playerHealthPoints -= damage;

        if(playerHealthPoints < 0)
        {
            playerHealthPoints = 0;

        }
        UpdatePlayerHP_Slider();
    }

    public void HealPlayer(float heal)
    {
        playerHealthPoints += heal;

        if(playerHealthPoints > playerMaxHealth)
        {
            playerHealthPoints = playerMaxHealth;
        }
        UpdatePlayerHP_Slider();
    }

    private void UpdatePlayerHP_Slider()
    {
        playerLifeSlider.value = playerHealthPoints;
        if(playerHealthPoints <=0)
        {
            StartCoroutine(GameManager.instance.LoseGame());
        }
    }

}
