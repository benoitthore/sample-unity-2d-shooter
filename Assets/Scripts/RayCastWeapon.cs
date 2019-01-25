using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public GameObject createEffect;
    public LineRenderer lineRenderer;
    public GameObject targetPrefab;
    private GameObject target;

    private GameObject explosionTmp;

    private void Start()
    {
        target = Instantiate(targetPrefab);
        lineRenderer.transform.position = Vector3.zero;
        lineRenderer.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        var firePosition = firePoint.position;
        if (explosionTmp)
        {
            Destroy(explosionTmp);
        }

        explosionTmp = Instantiate(createEffect, firePoint.position, createEffect.transform.rotation);
        if (firePoint.rotation.y < 0)
        {
            explosionTmp.transform.Rotate(0f, 180f, 0f);
        }


        var from = firePoint.position;
        var to = firePosition - target.transform.position;


        RaycastHit2D hitInfo = Physics2D.Raycast(firePosition, to);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            var impactTmp = Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firePosition);
            lineRenderer.SetPosition(1, hitInfo.point);

            Destroy(impactTmp, 2f);
        }
        else
        {
            lineRenderer.SetPosition(0, firePosition);
            lineRenderer.SetPosition(1, to);
        }

        lineRenderer.enabled = true;

        yield return 0;

        lineRenderer.enabled = false;
    }
}