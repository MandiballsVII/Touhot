using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float enemyMaxHealth;
    //public TMP_Text enemyLifeText;

    public SpriteRenderer[] bossSprites;
    private Color bossSpritesOG_Color;

    [SerializeField]private float enemyHealthPoints;
    public bool vulnerable = false;
    public bool isEnemyDead = false;

    private void Start()
    {
        enemyHealthPoints = enemyMaxHealth;
        bossSpritesOG_Color = bossSprites[0].color;
    }

    public void DealDamageToEnemy(float damage)
    {
        enemyHealthPoints -= damage;
        StartCoroutine(HitBoss());
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

    private IEnumerator HitBoss()
    {
        for(int i = 0; i < bossSprites.Length; i++) 
        {
            bossSprites[i].color = Color.darkRed;
        }
        yield return new WaitForSeconds(0.1f);
        
        for (int i = 0; i < bossSprites.Length; i++)
        {
            bossSprites[i].color = bossSpritesOG_Color;
        }
    }
}
