using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMaca : Tower
{

    public GameObject particule;
    GameObject instanceParticule;
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Attack();
        }
    }
    public override void Attack(float damageTogive = 0)
    {
        GameObject tower = FindNearestTarget(towers);
        if (tower != null)
        {
            tower.GetComponent<Tower>().Heal(10f);
            if (instanceParticule == null)
                instanceParticule = Instantiate(particule, tower.transform.position, Quaternion.identity, tower.transform);

            TakeDamage(10f);
        }
    }

    public override void InstantateProjectile()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Tower>() != null)
        {
            towers.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Tower>() != null)
        {
            towers.Remove(other.gameObject);
        }
    }
}
