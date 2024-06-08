using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : Entity
{
    [SerializeField] protected float fireRate = 1f;
    protected float nextFire;

    public GameObject prefabProjectile;
    public Transform bulletOrigin;
    public List<GameObject> targets = new List<GameObject>();
    public override void Start()
    {
        base.Start();
        gameObject.layer = LayerMask.NameToLayer("Obstaculo");
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    public virtual void VerifyLife()
    {
        if (currentLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public override void Update()
    {
        VerifyLife();
    }

    public override void Attack(float damageTogive = 0)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            InstantateProjectile();
            TakeDamage(10f);
        }
    }
    public abstract void InstantateProjectile();

    public GameObject FindClosestTarget()
    {
        if (targets == null || targets.Count == 0)
        {
            return null;
        }

        GameObject nearestObject = null;
        float maxDistance = 0;
        Vector2 referencePosition = transform.position;

        foreach (GameObject obj in targets)
        {
            if (obj != null)
            {
                float distance = Vector2.Distance(referencePosition, obj.transform.position);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    nearestObject = obj;
                }
            }
        }
        return nearestObject;
    }
    public GameObject FindNearestTarget()
    {
        if (targets == null || targets.Count == 0)
        {
            return null;
        }

        GameObject nearestObject = null;
        float minDistance = Mathf.Infinity;
        Vector2 referencePosition = transform.position;

        foreach (GameObject obj in targets)
        {
            if (obj != null)
            {
                float distance = Vector2.Distance(referencePosition, obj.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestObject = obj;
                }
            }
        }
        return nearestObject;
    }
}
