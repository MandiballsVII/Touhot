using TMPro;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float enemyMaxHealth;
    //public TMP_Text enemyLifeText;

    [SerializeField]private float enemyHealthPoints;
    public bool vulnerable = false;

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
            GameManager.instance.mouthWeapon[0].StopAllCoroutines();
            GameManager.instance.mouthWeapon[1].StopAllCoroutines();
            StartCoroutine(GameManager.instance.WinGame());
        }
    }
}
