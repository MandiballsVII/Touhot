using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    public GameObject healingItemPrefab;

    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;

    public PlayerLife PlayerLife;

    private float timer;
    private float currentSpawnTime;

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        if (PlayerLife == null) return;

        if (PlayerLife.playerHealthPoints <= PlayerLife.playerMaxHealth * 0.60f)
        {
            timer += Time.deltaTime;

            if (timer >= currentSpawnTime)
            {
                SpawnHealingItem();
                timer = 0f;
                SetNextSpawnTime(); // nuevo tiempo aleatorio
            }
        }
    }

    void SetNextSpawnTime()
    {
        currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }


    void SpawnHealingItem()
    {
        float randomX = Random.Range(-22f, 22f); // ajusta a tu juego
        Vector2 spawnPos = new Vector2(randomX, transform.position.y);

        Instantiate(healingItemPrefab, spawnPos, Quaternion.identity);
    }
}
