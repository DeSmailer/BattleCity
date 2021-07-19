using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacable
{
    public Teams GetTeam();
    public void TakeDamage(float damage);
    public void Dead();
}
