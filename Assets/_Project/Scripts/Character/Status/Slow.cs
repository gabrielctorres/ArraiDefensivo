using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Debuff", menuName = "Rumble/Debuffs/Slow", order = 0)]
public class Slow : Debuff
{

    float oldSpeed;
    public override void Apply(Enemie target)
    {
        if (oldSpeed == 0)
        {
            oldSpeed = target.speed;

            target.speed = 0.7f;
        }
    }

    public override void Remove(Enemie target)
    {
        target.speed = oldSpeed;
    }
}
