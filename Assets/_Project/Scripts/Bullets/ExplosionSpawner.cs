using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    public GameObject explosion;
    GameObject explosionInstance;

    public bool canExplode;

    public Transform pointSpawn;
    private void Update()
    {
        if (canExplode)
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        if (explosionInstance == null && pointSpawn != null)
            explosionInstance = Instantiate(explosion, pointSpawn.position, Quaternion.identity);
    }
}
