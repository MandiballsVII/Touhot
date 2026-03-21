using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float MAX_LIFE_TIME = 3f;
    private float lifeTime = 0f;

    public Vector2 velocity;

    private void Update()
    {
        transform.position += (Vector3)velocity * Time.deltaTime;
        lifeTime += Time.deltaTime;

        if(lifeTime > MAX_LIFE_TIME)
        {
            Disable();
        }
    }

    private void Disable()
    {
        lifeTime = 0f;
        gameObject.SetActive(false);
    }
}
