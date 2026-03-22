using System.Collections;
using UnityEngine;

public class RadialShotWeapon : MonoBehaviour
{
    public RadialShotPattern shotPattern;
    Vector2 center;
    [HideInInspector] public bool onShotPattern = false;
    [SerializeField] private EnemyLife enemyLife;

    private void Update()
    {
        if (onShotPattern || enemyLife.isEnemyDead)
        {
            return;
        }
        StartCoroutine(ExecuteRadialShotPattern(shotPattern));
    }

    public IEnumerator ExecuteRadialShotPattern(RadialShotPattern pattern)
    {
        onShotPattern = true;
        int lap = 0;
        Vector2 aimDirection = transform.up * -1;

        yield return new WaitForSeconds(pattern.StartWait);

        while (lap < pattern.Repetitions)
        {
            if (lap >0 && pattern.angleOffsetBetweenReps != 0f)
            {
                aimDirection  = aimDirection.Rotate(pattern.angleOffsetBetweenReps);
            }

            for(int i = 0; i < pattern.patternSettings.Length; i++)
            {
                center = transform.position;
                ShotAttack.RadialShot(center, aimDirection, pattern.patternSettings[i]);
                yield return new WaitForSeconds(pattern.patternSettings[i].CooldownAfterShot);
            }
            lap++;
        }

        yield return new WaitForSeconds(pattern.EndWait);


        onShotPattern = false;
    }
}
