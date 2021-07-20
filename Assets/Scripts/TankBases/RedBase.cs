using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBase : TankBase
{
    private new void Start()
    {
        base.Start();
        SpawnTank();
        SpawnTank();
        SpawnTank();
        SpawnTank();
        SpawnTank();
    }
}
