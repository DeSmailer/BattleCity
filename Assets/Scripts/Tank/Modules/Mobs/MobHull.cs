using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHull : Hull
{
    public Transform target;
    public float nextWayPointDistance = 1.5f;

    Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

   private Seeker seeker;
    private void Start()
    {
        target= GameObject.FindGameObjectWithTag("Player").transform;
        seeker = GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0.1f, 0.7f);
    }

    private void UpdatePath()
    {

        if (seeker.IsDone())
        {
            seeker.StartPath(rb2d.position, target.position, OnPathComplite);
        }
    }

    private void OnPathComplite(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void Update()
    {
        Move();
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;

        }

        moveDir = ((Vector2)path.vectorPath[currentWaypoint] - rb2d.position).normalized;
        //new Vector3(goHorizontal, goVertical).normalized;

        rb2d.velocity = moveDir * speed * Time.deltaTime;

        if (moveDir != Vector3.zero)
        {
            lookDir = new Vector3(-moveDir.y, moveDir.x);
            transform.parent.rotation = Quaternion.LookRotation(new Vector3(0, 0, 90), lookDir);
        }

        float distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWayPointDistance)
        {
            currentWaypoint++;
        }
    }
}
