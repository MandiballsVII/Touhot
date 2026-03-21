using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float shotCooldown;
    [SerializeField] private RadialShotSettings shotSettings;

    private float shotCooldownTimer = 0f;

    private void Update()
    {
        shotCooldownTimer -=Time.deltaTime;

        if(shotCooldownTimer <= 0f)
        {
            ShotAttack.RadialShot(transform.position, transform.up, shotSettings);
            shotCooldownTimer += shotCooldown;
        }
    }
    
}
