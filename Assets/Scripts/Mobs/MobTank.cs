using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobTank : Tank
{
    public abstract void SearchTarget();

    public void OnCollisionEnter2D(Collision2D collision)
    {
        IPickUp equipament = collision.gameObject.GetComponent(typeof(IPickUp)) as IPickUp;
        if (equipament != null)
        {
            ModuleData module = equipament.PickUp(GetTeam());
            Equip(module);
        }
    }
}
