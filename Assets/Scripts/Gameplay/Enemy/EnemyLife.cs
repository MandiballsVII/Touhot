using TMPro;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float enemyMaxHealth;
    //public TMP_Text enemyLifeText;

    [SerializeField]private float enemyHealthPoints;
    public bool vulnerable = false;
    public bool isEnemyDead = false;

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
        AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.Impact, transform.position);
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
        if(enemyHealthPoints <=0 && !isEnemyDead)
        {
            isEnemyDead = true;
            GameManager.instance.mouthWeapon[0].StopAllCoroutines();
            GameManager.instance.mouthWeapon[1].StopAllCoroutines();
            StartCoroutine(GameManager.instance.WinGame());
        }
    }
}
