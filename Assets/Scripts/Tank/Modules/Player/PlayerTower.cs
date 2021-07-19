using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : Tower
{
    private void Update()
    {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        LookAt(mousePosition);
    }
}
