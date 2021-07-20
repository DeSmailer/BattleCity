using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tank
{
    
    private void Update()
    {
        hull.Move();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            PickUp();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            DestroyModule();
        }

    }
}
