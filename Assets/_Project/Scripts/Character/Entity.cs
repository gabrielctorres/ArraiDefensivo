using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected float currentLife;
    protected float maxLife;
    protected float damage;

    public virtual void Start()
    {
        currentLife = maxLife;
    }
    public virtual void Attack(float damageTogive = 0) { }

    public virtual void TakeDamage(float damageToRecive)
    {
        if (currentLife > 0)
        {
            currentLife -= damageToRecive;
        }
    }

}
