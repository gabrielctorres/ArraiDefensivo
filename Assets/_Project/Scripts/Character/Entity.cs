using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Variáveis Gerais")]
    //Geral
    protected float currentLife;
    [SerializeField] protected float maxLife;
    protected float damage;

    //Interno
    protected float tier;

    public virtual void Start()
    {
        currentLife = maxLife;
    }

    //Ataque
    public virtual void Attack(float damageTogive = 0) { }

    //Tomar dano
    public virtual void TakeDamage(float damageToRecive)
    {
        if (currentLife > 0)
        {
            currentLife -= damageToRecive;
        }
    }

}
