using System;
using System.Diagnostics;
using System.Collections;
using UnityEngine;


public class Medkit : MonoBehaviour
{

    public float healAmount = 40f;
    public float speed = 10f;
    public float lifetime = 5f;
    public ParticleSystem grabFX;

    void Start()
    {
        Destroy(gameObject, lifetime);

    }
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("holiwi");
            // collision.gameObject.GetComponent<PlayerLife>().miniHeal(healAmount);
            //collision.gameObject.GetComponent<PlayerLife>();

            PlayerLife PlayerLife = other.GetComponent<PlayerLife>();

            if (PlayerLife != null)
            {
                PlayerLife.miniHeal(healAmount);
            }
            Instantiate(grabFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    /*private void Disable()
    {
        Destroy(gameObject);
    }*/
}
