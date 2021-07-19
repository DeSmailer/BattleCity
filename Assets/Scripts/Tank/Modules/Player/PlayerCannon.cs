using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannon : Cannon
{
    private void Update()
    {
        timeBtwShoot -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (timeBtwShoot <= 0)
            {
                Shoot();
            }
        }
    }
}
