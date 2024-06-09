using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    private CircleCollider2D coll2D;
    private ParticleSystem explosionParticles;

    void Start()
    {
        coll2D = GetComponent<CircleCollider2D>();
        explosionParticles = GetComponentInChildren<ParticleSystem>();

        if (coll2D == null)
        {
            Debug.LogError("CircleCollider2D not found.");
            return;
        }

        if (explosionParticles == null)
        {
            Debug.LogError("ParticleSystem not found.");
            return;
        }

        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        coll2D.enabled = true;
        explosionParticles.Play();

        yield return new WaitForSeconds(2f);

        coll2D.enabled = false;
        coll2D.radius = 0.5f;
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemie enemy = other.GetComponent<Enemie>();
        if (enemy != null)
        {
            enemy.TakeDamage(4f);
        }
    }
}
