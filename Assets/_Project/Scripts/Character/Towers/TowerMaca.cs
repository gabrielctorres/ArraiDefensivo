using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TowerMaca : Tower
{
    public GameObject particule;
    private GameObject instanceParticule;
    private int tierHealCount = 1;

    public override void Start()
    {
        base.Start();
    }

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

        tierHealCount = Mathf.Min(level, 3);

        List<GameObject> towersToHeal = FindNearestTargets(towers, tierHealCount);
        Debug.Log(towersToHeal.Count);
        Debug.Log(tierHealCount);
        foreach (GameObject tower in towersToHeal)
        {
            if (tower != null)
            {
                tower.GetComponent<Tower>().Heal(10f);
                TakeDamage(10f);
                instanceParticule = Instantiate(particule, tower.transform.position, Quaternion.identity, tower.transform);

            }
        }

    }

    private List<GameObject> FindNearestTargets(List<GameObject> availableTowers, int count)
    {
        List<GameObject> nearestTargets = new List<GameObject>();
        Vector2 currentPosition = transform.position;

        // Ordena as torres pela distância em relação à torre atual
        availableTowers.Sort((a, b) =>
            Vector2.Distance(currentPosition, a.transform.position).CompareTo(Vector2.Distance(currentPosition, b.transform.position)));

        // Adiciona as torres mais próximas até o limite especificado
        for (int i = 0; i < Mathf.Min(count, availableTowers.Count); i++)
        {
            nearestTargets.Add(availableTowers[i]);
        }

        return nearestTargets;
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
