using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCannon : Cannon
{
    private void Update()
    {
        timeBtwShoot -= Time.deltaTime;
    }
    public override void Shoot()
    {
        if (timeBtwShoot <= 0)
        {
            base.Shoot();
        }
    }
}
