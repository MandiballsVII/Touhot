using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    private PlayerController playerController;

    [SerializeField] private EnemyLife enemyLife;

    private float timeScale = 1;

    private float timeScaleObjective;

    public float lerpSpeed;

    public float minTimeScale;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }


    private void Update()
    {
        if (enemyLife.isEnemyDead)
        {
            Time.timeScale = 1;
            return;
        }
        if(playerController.moveDirection != Vector2.zero)
        {
            timeScaleObjective = 1;
            timeScale = Mathf.Lerp(timeScale, timeScaleObjective, Time.deltaTime * lerpSpeed);
        }
        else
        {
            timeScaleObjective = minTimeScale;
            timeScale = Mathf.Lerp(timeScale, timeScaleObjective, Time.deltaTime * lerpSpeed);
        }
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = timeScale * 0.02f;
        //Debug.Log(Time.timeScale);
    }

}
