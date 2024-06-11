using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEsptin : Tower
{
    private Quaternion originalRotation;
    DebuffGiver debuffGiver;
    public override void Start()
    {
        base.Start();
        debuffGiver = GetComponent<DebuffGiver>();
        originalRotation = bulletOrigin.transform.rotation; // Salva a rotação original da torre
    }

    public override void Update()
    {
        base.Update();

        if (targets.Count > 0)
        {
            MeleeAttack();
        }
        if (level >= 2) fireRate = 1f;

        if (level == 3) debuffGiver.canApplyEffect = true;
    }

    private void MeleeAttack()
    {
        GameObject nearestEnemy = FindClosestTarget();
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(RotateToTarget(nearestEnemy));
            AttackNearestEnemy(nearestEnemy);
            TakeDamage(damage / 2);
        }
    }

    private IEnumerator RotateToTarget(GameObject target)
    {
        Vector2 direction = -(target.transform.position - bulletOrigin.transform.position);
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        bulletOrigin.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        yield return new WaitForSeconds(0.3f);
        bulletOrigin.transform.rotation = originalRotation;
    }

    private void AttackNearestEnemy(GameObject target)
    {
        if (target != null)
        {
            target.GetComponent<Enemie>().TakeDamage(damage);
        }
    }

    public override void InstantateProjectile()
    {
        // Implementação vazia, pois a torre Espetin não atira projéteis
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
