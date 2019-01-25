using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public float damage = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Creating particle system");
    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnParticleCollision(GameObject other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }
    }
}