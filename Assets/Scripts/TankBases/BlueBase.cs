using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBase : TankBase
{
    public GameObject playerPref;
    private new void Start()
    {
        base.Start();
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPref, new Vector3(spawnPoints[0].position.x, spawnPoints[0].position.y, spawnPoints[0].position.z - 5), Quaternion.identity);
        Tank playerTank = player.GetComponent<Tank>();
        playerTank.Equip(randomEquipmentManager.GetHull());
        playerTank.Equip(randomEquipmentManager.GetTower());
        playerTank.Equip(randomEquipmentManager.GetCannon());
        ReduceNumberOfAvailableUnits();
    }
    public override void SpawnTank()
    {
        throw new System.NotImplementedException();
    }
}
