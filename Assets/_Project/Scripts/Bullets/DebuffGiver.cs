using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffGiver : MonoBehaviour
{
    public Debuff effect;
    public bool canApplyEffect;
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canApplyEffect)
        {
            if (other.GetComponent<DebuffReciver>() != null)
                other.GetComponent<DebuffReciver>().AddEffect(effect);
        }
    }
}
