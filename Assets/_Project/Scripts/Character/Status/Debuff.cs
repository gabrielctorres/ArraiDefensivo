using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Debuff : ScriptableObject
{
    public string nameEffect;
    public string descripton;
    public GameObject visualEffect;
    public float cooldown;
    public float tickSpeed;
    public abstract void Apply(Enemie target);

    public abstract void Remove(Enemie target);
}
