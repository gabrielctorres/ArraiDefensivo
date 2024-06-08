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
    public abstract void Apply(Entity target);

    public abstract void Remove(Entity target);
}
