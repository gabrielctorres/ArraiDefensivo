using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Debuff", menuName = "Rumble/Debuffs/Ignite", order = 0)]
public class Ignite : Debuff
{
    public override void Apply(Enemie target)
    {
        target.TakeDamage(1f);
    }

    public override void Remove(Enemie target)
    {

    }


}
