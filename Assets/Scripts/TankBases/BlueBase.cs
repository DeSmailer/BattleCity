using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBase : TankBase
{
    public GameObject playerPref;
    public GameObject mobPref;
    private new void Start()
    {
        base.Start();
        SpawnPlayer(); 
        SpawnTank();
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
        foreach(Transform spawnPoint in spawnPoints)
        {
            if (CheckPositionForSpawn(spawnPoint))
            {
                GameObject mob = Instantiate(mobPref, new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z - 5), Quaternion.identity);
                Tank mobTank = mob.GetComponent<Tank>();
                mobTank.Equip(randomEquipmentManager.GetHull());
                mobTank.Equip(randomEquipmentManager.GetTower());
                mobTank.Equip(randomEquipmentManager.GetCannon());
                ReduceNumberOfAvailableUnits();
                break;
            }
        }
    }
}
