using UnityEngine;

public static class ShootAttack
{
    public static void SimpleShoot(Vector2 origin, Vector2 velocity)
    {
        Bullet bullet = BulletPool.Instance.RequestBullet();
        bullet.transform.position = origin;
        bullet.velocity = velocity;
    }

    public static void RadialShoot(Vector2 origin, Vector2 aimDirection, RadialShootSettings settings)
    {
        float angleBetweenBullets = 360f / settings.numberOfBullets;

        for (int i = 0; i < settings.numberOfBullets; i++)
        {
            float bulletDirectionAngle = angleBetweenBullets * i;

            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);

            SimpleShoot(origin, bulletDirection * settings.bulletSpeed);
        }
    }
}
