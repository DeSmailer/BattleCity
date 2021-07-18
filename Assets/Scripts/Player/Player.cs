using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tank
{
    private void Start()
    {
        hull.Start();
    }
    private void Update()
    {
        hull.Move();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            PickUp();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Drop();
        }
    }
}
