using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerTank : Tank
{
    public LayerMask layerMask;
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
            else
            {
                if (Physics.Linecast(transform.position, target.position))
                {
                    Debug.Log("blocked");
                }
            }

            tower.LookAt(target.position);

            if (Vector2.Distance(transform.position, target.transform.position) <= cannon.shotDistance)
            {
                cannon.Shoot();
            }
        }
    }
    private void SearchTarget()
    {
        GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPickUp equipament = collision.gameObject.GetComponent(typeof(IPickUp)) as IPickUp;
        if (equipament != null)
        {
            ModuleData module = equipament.PickUp(team);
            Equip(module);
        }
    }
}
