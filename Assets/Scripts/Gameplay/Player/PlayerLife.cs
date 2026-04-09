using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float playerMaxHealth;
    public Slider playerLifeSlider;
    
    public float playerHealthPoints; //estaba privada

    private bool isPlayerDead = false;

    private void Start()
    {
        playerHealthPoints = playerMaxHealth;
        UpdatePlayerHP_Slider();
    }

    public void DealDamageToPlayer(float damage)
    {
        playerHealthPoints -= damage;

        if (playerHealthPoints < 0)
        {
            playerHealthPoints = 0;

        }
        UpdatePlayerHP_Slider();
        AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.ImpactOnPlayer, transform.position);
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

    public void miniHeal(float amount) //nueva void
    {
        playerHealthPoints += amount;
        playerHealthPoints = Mathf.Clamp(playerHealthPoints, 0f, playerMaxHealth);
        UpdatePlayerHP_Slider();
    }

    private void UpdatePlayerHP_Slider()
    {
        playerLifeSlider.value = playerHealthPoints;
        if(playerHealthPoints <=0 && !isPlayerDead)
        {
            isPlayerDead = true;
            StartCoroutine(GameManager.instance.LoseGame());
        }
    }

}
