using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class TowerPacoca : Tower
{
    public List<GameObject> pacocaObjects = new List<GameObject>();
    private int index = 0;
    private int aux = 0;
    private int countProjectile = 1;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        if (targets.Count > 0)
        {
            Attack();
        }
    }

    public override void TakeDamage(float damageToRecive)
    {
        if (currentLife > 0)
        {
            currentLife -= damageToRecive;
            aux++;

            if (aux == 2)
            {
                if (index < (pacocaObjects.Count - 1) && pacocaObjects[index].activeInHierarchy)
                {
                    pacocaObjects[index].SetActive(false);
                    index++;
                }

                aux = 0;
            }

            if (index >= pacocaObjects.Count)
            {
                index = 0;
            }
        }
    }

    public override void InstantateProjectile()
    {
        for (int i = 0; i < level; i++)
        {
            Vector2 offset = new Vector2(0, i * 0.8f); // Offset to slightly separate the projectiles
            Vector2 spawnPosition = (Vector2)bulletOrigin.position + offset;
            GameObject instanceProjectile = Instantiate(prefabProjectile, spawnPosition, Quaternion.identity);
            instanceProjectile.GetComponent<Bullet>().damage = damage;
            if (instanceProjectile.TryGetComponent<Bullet>(out Bullet bullet))
            {
                bullet.Target = FindClosestTarget().transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemie>() != null)
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Enemie>() != null)
        {
            targets.Remove(other.gameObject);
        }
    }
}
