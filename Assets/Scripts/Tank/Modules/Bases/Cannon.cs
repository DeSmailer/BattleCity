using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cannon : Module
{
    public GameObject projectile;

    public Tower tower;

    public float timeBtwShoot = 1f;
    public float startTimeBtwShoot = 1f;

    public float damage;
    public float shotDistance;

    public int gunsCount;
    public Transform centralFirePoint;
    public Transform[] firePoints;

    public SpriteRenderer spriteRenderer;
    public void Start()
    {
        timeBtwShoot = startTimeBtwShoot;
    }

    public override void Equip(ModuleData moduleData)
    {
        if (moduleData is CannonData)
        {
            this.moduleData = moduleData;
            CannonData cannonData = (CannonData)moduleData;

            damage = cannonData.Damage;
            shotDistance = cannonData.ShotDistance;
            gunsCount = cannonData.GunsCount;

            for (int i = 0; i < gunsCount; i++)
            {
                firePoints[i].position = centralFirePoint.transform.position + (Vector3)cannonData.FirePoints[i];
            }

            spriteRenderer.sprite = cannonData.Sprite;
        }
        else
        {
            print("ошибочка");
        }
    }

    public void Shoot()
    {
        for (int i = 0; i < gunsCount; i++)
        {
            GameObject projectileInstance = Instantiate(projectile, firePoints[i].position, transform.rotation);
            ProjectileSettings projectileSettings = new ProjectileSettings(tower.shotAccuracy, damage, shotDistance, team);
            projectileInstance.GetComponent<Projectile>().Init(projectileSettings);
        }
        timeBtwShoot = startTimeBtwShoot;
    }

}
