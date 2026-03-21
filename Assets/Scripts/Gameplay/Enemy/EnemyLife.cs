using TMPro;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float enemyMaxHealth;
    public TMP_Text enemyLifeText;

    private float enemyHealthPoints;

    private void Start()
    {
        enemyHealthPoints = enemyMaxHealth;
        UpdateEnemyHP_Text();
    }

    public void DealDamageToEnemy(float damage)
    {
        enemyHealthPoints -= damage;

        if (enemyHealthPoints < 0)
        {
            enemyHealthPoints = 0;

        }
        UpdateEnemyHP_Text();
    }

    public void HealPlayer(float heal)
    {
        enemyHealthPoints += heal;

        if (enemyHealthPoints > enemyMaxHealth)
        {
            enemyHealthPoints = enemyMaxHealth;
        }
        UpdateEnemyHP_Text();
    }

    private void UpdateEnemyHP_Text()
    {
        enemyLifeText.text = ("Enemy HP: " + enemyHealthPoints);
    }
}
