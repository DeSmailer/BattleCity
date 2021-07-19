using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHull : Hull
{
    public override void Move()
    {
        goHorizontal = Input.GetAxisRaw("Horizontal");
        goVertical = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(goHorizontal, goVertical).normalized;

        rb2d.velocity = moveDir * speed * Time.deltaTime;

        if (moveDir != Vector3.zero)
        {
            lookDir = new Vector3(-goVertical, goHorizontal);
            transform.parent.rotation = Quaternion.LookRotation(new Vector3(0, 0, 90), lookDir);
        }
    }
    public override void Dead()
    {
        throw new System.NotImplementedException();
    }
}
