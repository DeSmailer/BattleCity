using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBase : MonoBehaviour, IAttacable
{
    [SerializeField]
    private Teams team;
    [SerializeField]
    private int unitsLeft;

    public Vector3[] spawnPoints;
    public GameObject[] mobTanksPref;

    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float currentHP;

    [SerializeField]
    private float checkRadius = 0.45f;

    public RandomEquipmentManager randomEquipmentManager;

    public int tanksOnTheField;

    public void Start()
    {
        currentHP = maxHP;
        spawnPoints = new Vector3[] {
            new Vector3(transform.position.x+1,transform.position.y,transform.position.z+1),
            new Vector3(transform.position.x-1,transform.position.y,transform.position.z+1),
            new Vector3(transform.position.x,transform.position.y+1,transform.position.z+1),
            new Vector3(transform.position.x,transform.position.y-1,transform.position.z+1),
        };
    }
    public void SpawnTank()
    {
        if (unitsLeft > 0 && tanksOnTheField < 2)
        {
            foreach (Vector3 spawnPoint in spawnPoints)
            {
                if (CheckPositionForSpawn(spawnPoint))
                {
                    int rand = Random.Range(0, mobTanksPref.Length);

                    GameObject mob = Instantiate(mobTanksPref[rand], new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z - 5), Quaternion.identity);
                    Tank mobTank = mob.GetComponent<Tank>();
                    mobTank.team = team;
                    mobTank.Equip(randomEquipmentManager.GetHull());
                    mobTank.Equip(randomEquipmentManager.GetTower());
                    mobTank.Equip(randomEquipmentManager.GetCannon());

                    mobTank.Notify += ReduceTanksOnTheField;
                    mobTank.Notify += SpawnTank;

                    ReduceNumberOfAvailableUnits();
                    IncreaseTanksOnTheField();
                    break;
                }
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Dead();
        }
    }

    public bool CheckPositionForSpawn(Vector3 spawnPoint)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(spawnPoint, checkRadius);

        if (hitColliders.Length <= 0)
        {
            return true;
        }
        return false;
    }

    public void ReduceNumberOfAvailableUnits()
    {
        unitsLeft--;
    }

    private void OnDrawGizmos()
    {
        foreach (Vector3 spawnPoint in spawnPoints)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(spawnPoint, checkRadius);
        }
    }

    public virtual void Dead()
    {
        Destroy(gameObject);
    }

    public Teams GetTeam()
    {
        return team;
    }
    public void ReduceTanksOnTheField()
    {
        tanksOnTheField--;
    }
    public void IncreaseTanksOnTheField()
    {
        tanksOnTheField++;
    }
}
