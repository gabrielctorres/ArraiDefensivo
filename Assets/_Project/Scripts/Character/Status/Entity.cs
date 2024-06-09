using UnityEngine;
using UnityEngine.UI;
public class Entity : MonoBehaviour
{

    [Header("Variaveis Gerais")]

    //Geral
    protected float currentLife = 100f;
    [SerializeField] protected float maxLife;

    public Image imageLifeFill;
    protected float damage;

    //Interno
    public int level;

    public virtual void Start()
    {
        currentLife = maxLife;
        level = 1;
    }
    public virtual void Update()
    {

    }
    public virtual void VerifyLife()
    {

        imageLifeFill.fillAmount = currentLife / maxLife;
        if (currentLife <= 0)
        {
            Destroy(this.gameObject);
        }
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
