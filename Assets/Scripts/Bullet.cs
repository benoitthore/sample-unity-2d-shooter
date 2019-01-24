using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float lifeTime;

    // Use this for initialization
    void Start()
    {
        if (rb)
        {
            rb.velocity = transform.right * speed;
        }

        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(hitInfo.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            return;
        }

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (impactEffect)
        {
            Destroy(
                Instantiate(impactEffect, transform.position, transform.rotation),
                2f);
        }

        Destroy(gameObject);
    }
}