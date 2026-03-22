using UnityEngine;
using UnityEditor;
using static UnityEngine.UI.Image;

[ExecuteAlways]
public class RS_Visualizer : MonoBehaviour
{
    [SerializeField] private RadialShotPattern pattern;
    [SerializeField] private float radius;
    [SerializeField] private Color color;
    [SerializeField, Range(0f, 10f)] private float testTime;

    private void OnDrawGizmos()
    {
        if(pattern == null)
        {
            return;
        }
        Gizmos.color = color;

        int lap = 0;
        Vector2 aimDirection = transform.up * -1;
        Vector2 center = transform.position;

        float timer = testTime;


        while (timer > 0f && lap < pattern.Repetitions)
        {
            
            if (lap > 0 && pattern.angleOffsetBetweenReps != 0f)
            {
                aimDirection = aimDirection.Rotate(pattern.angleOffsetBetweenReps);
            }

            for (int i = 0; i < pattern.patternSettings.Length; i++)
            {
                if(timer < 0f)
                    break;

                DrawRadialShot(pattern.patternSettings[i], timer, aimDirection);
                timer -= pattern.patternSettings[i].CooldownAfterShot;
            }
            lap++;
        }

    }

    private void DrawRadialShot(RadialShotSettings settings, float lifeTime, Vector2 aimDirection)
    {
        float angleBetweenBullets = 360f / settings.numberOfBullets;

        if (settings.angleOffset != 0 || settings.phaseOffset != 0)
        {
            aimDirection = aimDirection.Rotate(settings.angleOffset + (settings.phaseOffset * angleBetweenBullets));
        }

        for (int i = 0; i < settings.numberOfBullets; i++)
        {
            float bulletDirectionAngle = angleBetweenBullets * i;

            if (settings.RadialMask && bulletDirectionAngle > settings.MaskAngle)
            {
                break;
            }

            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            Vector2 bulletPosition = (Vector2)transform.position + (bulletDirection * settings.bulletSpeed * lifeTime);

            Gizmos.DrawSphere(bulletPosition, radius);
        }
    }
}
