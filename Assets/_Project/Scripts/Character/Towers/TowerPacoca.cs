using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TowerPacoca : Tower
{
    public List<GameObject> pacocaObjects = new List<GameObject>();
    int index = 0;
    int aux;
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
                if (index < pacocaObjects.Count && pacocaObjects[index].activeInHierarchy)
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
        GameObject instanceProjectile = Instantiate(prefabProjectile, bulletOrigin.position, Quaternion.identity);
        instanceProjectile.GetComponent<Bullet>().Target = FindClosestTarget().transform;
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
