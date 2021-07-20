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
        SpawnTank();
    }
    public void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPref, new Vector3(spawnPoints[0].x, spawnPoints[0].y, spawnPoints[0].z - 5), Quaternion.identity);
        Tank playerTank = player.GetComponent<Tank>();
        playerTank.Equip(randomEquipmentManager.GetHull());
        playerTank.Equip(randomEquipmentManager.GetTower());
        playerTank.Equip(randomEquipmentManager.GetCannon());
        ReduceNumberOfAvailableUnits();
        IncreaseTanksOnTheField();
    }
    
    public override void Dead()
    {
        ResultGame.Lose();
        base.Dead();
    }
}
