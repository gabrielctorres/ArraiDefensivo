using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    CircleCollider2D coll2D;
    void Start()
    {
        coll2D = GetComponent<CircleCollider2D>();
        Explosion();
    }

    public void Explosion()
    {
        coll2D.radius = 3f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemie>() != null)
        {
            other.GetComponent<Enemie>().TakeDamage(4f);
            //Dar Play na particula
        }

    }
}
