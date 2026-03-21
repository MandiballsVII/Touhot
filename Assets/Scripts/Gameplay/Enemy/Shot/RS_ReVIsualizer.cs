using UnityEngine;

public class RS_ReVIsualizer : MonoBehaviour
{
    //[SerializeField] private RadialShotSettings testRadialShot;
    [SerializeField] private RadialShotPattern pattern;
    [SerializeField] private float radius;
    [SerializeField] private Color color;
    [SerializeField, Range(0f, 5f)] private float testTime;

    private void OnDrawGizmos()
    {
        if(pattern != null)
        {
            return;
        }
        Gizmos.color = color;
        
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

            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            Vector2 bulletPosition = (Vector2)transform.position + (bulletDirection * settings.bulletSpeed * lifeTime);

            Gizmos.DrawSphere(bulletPosition, radius);
        }
    }
}
