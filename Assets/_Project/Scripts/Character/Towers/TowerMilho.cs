using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMilho : Tower
{



    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (targets.Count > 0)
        {
            Attack();
        }
    }


    public override void InstantateProjectile()
    {
        GameObject instanceProjectile = Instantiate(prefabProjectile, bulletOrigin.position, Quaternion.identity);
        instanceProjectile.GetComponent<Bullet>().Target = FindNearestTarget().transform;
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
