using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Tower : Entity
{
    [SerializeField] protected float fireRate = 1f;
    protected float nextFire;

    public GameObject prefabProjectile;
    public Transform bulletOrigin;
    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> towers = new List<GameObject>();

    public GameObject buttonUpgrade;
    public TextMeshProUGUI txtLevel;
    public float coastUpgrade;
    public Animator animator;
    public ParticleSystem levelUPEffect;
    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        if (animator != null)
            animator.SetBool("Start", true);
        gameObject.layer = LayerMask.NameToLayer("Obstaculo");
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    public override void VerifyLife()
    {

        imageLifeFill.fillAmount = currentLife / maxLife;
        if (currentLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Upgrade()
    {
        if (level < 3 && GameManager.instance.Money >= coastUpgrade)
        {
            level++;
            buttonUpgrade.SetActive(false);
            maxLife *= 1.3f;
            currentLife = maxLife;
            levelUPEffect.gameObject.SetActive(true);
            levelUPEffect.Play();
            GameManager.instance.Money -= coastUpgrade;
            coastUpgrade *= 1.7f;
        }
    }
    public override void Update()
    {
        if (GameManager.instance.Money >= coastUpgrade && level < 3)
        {
            buttonUpgrade.SetActive(true);

        }
        txtLevel.text = level.ToString();
        VerifyLife();
        if (animator != null)
            animator.SetFloat("Life", currentLife);
    }

    public override void Attack(float damageTogive = 0)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            InstantateProjectile();
            TakeDamage((damage / 2));
        }
    }
    public abstract void InstantateProjectile();
    public virtual void Heal(float value = 0)
    {
        if (currentLife < maxLife)
        {
            currentLife += value;
        }
    }
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
    public virtual GameObject FindNearestTarget(List<GameObject> objects)
    {
        if (objects == null || objects.Count == 0)
        {
            return null;
        }

        GameObject nearestObject = null;
        float minDistance = Mathf.Infinity;
        Vector2 referencePosition = transform.position;

        foreach (GameObject obj in objects)
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
