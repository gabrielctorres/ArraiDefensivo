using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    public GameObject explosion;
    GameObject explosionInstance;
    void Start()
    {
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        if (explosionInstance == null)
            explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
