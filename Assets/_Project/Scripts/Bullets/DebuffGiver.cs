using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffGiver : MonoBehaviour
{
    public Debuff effect;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DebuffReciver>() != null)
        {
            other.GetComponent<DebuffReciver>().AddEffect(effect);
        }
    }
}
