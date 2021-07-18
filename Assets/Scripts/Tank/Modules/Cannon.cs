using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Module
{
    public GameObject Bullet;
    //public Transform[] FirePoints;
    public float timeBtwShoot;
    public float startTimeBtwShoot;
    private void Start()
    {
        timeBtwShoot = startTimeBtwShoot;
    }

    //private void Update()
    //{
    //    timeBtwShoot -= Time.deltaTime;
    //    if (Input.GetMouseButton(0))
    //    {
    //        Shoot();
    //    }
    //    if (Input.GetMouseButton(0))
    //    {
    //        Shoot();
    //    }
    //}

    //private void Shoot()
    //{
    //    if (timeBtwShoot <= 0)
    //    {
    //        foreach(Transform firePoint in FirePoints)
    //        {
    //            Instantiate(Bullet, firePoint.position, firePoint.rotation);
    //            timeBtwShoot = startTimeBtwShoot;
    //        }
    //    }
    //}

    public override void Equip(ModuleData moduleData)
    {
        throw new System.NotImplementedException();
    }
}
