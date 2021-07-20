using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormtrooperTank : MobTank
{
    public LayerMask layerMaskForRaycast;
    private readonly string targetTag = "Base";

    public override void SearchTarget()
    {
        GameObject[] bases = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject item in bases)
        {
            Teams targetTeam = item.GetComponent<TankBase>().GetTeam();

            if (targetTeam != team)
            {
                target = item.transform;
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
            if (Vector2.Distance(transform.position, target.transform.position) > cannon.shotDistance)
            {
                hull.Move();
            }
            else
            {
                Vector2 dir = (target.position - transform.position) * 10;
                if (Physics2D.Raycast(transform.position, dir, Mathf.Infinity))
                {
                    hull.Move();
                }
            }

            tower.LookAt(target.position);

            if (Vector2.Distance(transform.position, target.transform.position) <= cannon.shotDistance)
            {
                cannon.Shoot();
            }
        }
    }
}