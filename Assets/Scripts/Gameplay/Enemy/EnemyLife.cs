using TMPro;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float enemyMaxHealth;
    //public TMP_Text enemyLifeText;

    private float enemyHealthPoints;

    private void Start()
    {
        enemyHealthPoints = enemyMaxHealth;
    }

    public void DealDamageToEnemy(float damage)
    {
        enemyHealthPoints -= damage;

        if (enemyHealthPoints < 0)
        {
            enemyHealthPoints = 0;
        }
        CheckGameEnded();
    }

    public void HealPlayer(float heal)
    {
        enemyHealthPoints += heal;

        if (enemyHealthPoints > enemyMaxHealth)
        {
            enemyHealthPoints = enemyMaxHealth;
        }
        CheckGameEnded();
    }

    private void UpdateEnemyHP_Text()
    {
        //enemyLifeText.text = ("Enemy HP: " + enemyHealthPoints);
    }

    private void CheckGameEnded()
    {
        if(enemyHealthPoints <=0)
        {
            StartCoroutine(GameManager.instance.WinGame());
        }
    }
}
