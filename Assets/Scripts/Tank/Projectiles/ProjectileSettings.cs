using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSettings
{
    public float shotAccuracy;
    public float damage;
    public float shotDistance;
    public Teams team;

    public ProjectileSettings(float shotAccuracy, float damage, float shotDistance, Teams team)
    {
        this.shotAccuracy = shotAccuracy;
        this.damage = damage;
        this.shotDistance = shotDistance;
        this.team = team;
    }
}
