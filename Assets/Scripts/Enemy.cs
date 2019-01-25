using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;

    public GameObject deathEffect;


    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

        if (deathEffect)
        {
            var deathEffectTmp = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(deathEffectTmp, 2f);
        }
    }
}