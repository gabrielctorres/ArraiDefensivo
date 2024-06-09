using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Debuff", menuName = "Rumble/Debuffs/Slow", order = 0)]
public class Slow : Debuff
{
    public override void Apply(Enemie target)
    {
        target.canMove = false;
    }

    public override void Remove(Enemie target)
    {
        target.canMove = true;
    }
}
