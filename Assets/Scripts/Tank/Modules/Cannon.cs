using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cannon : Module
{
    public GameObject projectile;


    public float timeBtwShoot;
    public float startTimeBtwShoot;

    public float damage;
    public float shotDistance;

    public int gunsCount;
    public Transform centralFirePoint;
    public Transform[] firePoints;

    public SpriteRenderer spriteRenderer;
    public void Start()
    {
        timeBtwShoot = startTimeBtwShoot;
        CannonData t = (CannonData)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ModulesData/BlueTeam/Cannons/PoweredCannon1.asset", typeof(CannonData));
        Equip(t);
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
                print(cannonData.FirePoints[i]);
            }

            spriteRenderer.sprite = cannonData.Sprite;
        }
        else
        {
            print("ошибочка");
        }
    }
    private void Update()
    {
        timeBtwShoot -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        print("высрел");
        if (timeBtwShoot <= 0)
        {
            for (int i = 0; i < gunsCount; i++)
            {
                Instantiate(projectile, firePoints[i].position, transform.rotation);
            }
            timeBtwShoot = startTimeBtwShoot;
        }
    }

}
