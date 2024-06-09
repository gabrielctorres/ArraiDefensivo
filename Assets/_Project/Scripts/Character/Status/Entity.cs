using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Variaveis Gerais")]
    //Geral
    protected float currentLife;
    [SerializeField] protected float maxLife;
    protected float damage;

    //Interno
    public float level;

    public virtual void Start()
    {
        currentLife = maxLife;
    }
    public virtual void Update()
    {

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
