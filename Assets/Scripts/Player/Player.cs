using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tank
{
    Camera mainCamera;
    private void Awake()
    {
        mainCamera = Camera.main;
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
        } if (Input.GetKeyDown(KeyCode.M))
        {
            DestroyModule();
        }
        Vector3 p = new Vector3(transform.position.x, transform.position.y, -10);
        mainCamera.transform.position = p;
    }
}
