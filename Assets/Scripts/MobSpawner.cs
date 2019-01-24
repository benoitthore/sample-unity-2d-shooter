using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public float minWait = 5f;
    public float maxWait = 10f;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    IEnumerator spawn()
    {
        while (gameObject)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
