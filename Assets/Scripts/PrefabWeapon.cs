using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject targetPrefab;
    public float shotsPerSecond;

    private GameObject target;
    private bool canShoot = true;

    private void Start()
    {
        target = Instantiate(targetPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector2 from = firePoint.transform.position;
        Vector2 to = target.transform.position;
        var direction = new Vector2(from.x - to.x, from.y - to.y);


        var bullet = Instantiate(bulletPrefab, from, firePoint.transform.rotation, transform);
        bullet.transform.right = -direction;

        StartCoroutine(lockShotWithDelay());
    }

    private IEnumerator lockShotWithDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f / shotsPerSecond);
        canShoot = true;
    }
}