using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerTank : MobTank
{

    private const string targetTag = "Tank";

    public override void SearchTarget()
    {
        GameObject[] tanks = GameObject.FindGameObjectsWithTag(targetTag);
        print(tanks);

        foreach (GameObject tank in tanks)
        {
            Teams targetTeam = tank.GetComponent<Tank>().GetTeam();

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
