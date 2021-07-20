using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormtrooperTank : MobTank
{
    private const string targetTag = "Base";

    public override void SearchTarget()
    {
        GameObject[] tanks = GameObject.FindGameObjectsWithTag(targetTag);
        print(tanks);

        foreach (GameObject tank in tanks)
        {
            Teams targetTeam = tank.GetComponent<TankBase>().GetTeam();

            if (targetTeam != team)
            {
                target = tank.transform;
                hull.SetTarget(target);
                break;
            }
        }
    }

    private void Update()
    {
        if (target == null)
        {
            SearchTarget();
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > cannon.shotDistance)
            {
                hull.Move();
            }

            tower.LookAt(target.position);

            if (Vector2.Distance(transform.position, target.transform.position) <= cannon.shotDistance)
            {
                cannon.Shoot();
            }
        }
    }
}