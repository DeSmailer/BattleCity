using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBase : MonoBehaviour, IAttacable
{
    [SerializeField]
    private Teams team;
    [SerializeField]
    private int unitsLeft;

    public Transform[] spawnPoints;

    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float currentHP;

    [SerializeField]
    private float checkRadius = 0.45f;

    public RandomEquipmentManager randomEquipmentManager;

    public void Start()
    {
        currentHP = maxHP;
    }
    public abstract void SpawnTank();

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Dead();
        }
    }

    public bool CheckPositionForSpawn(Transform spawnPoint)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(spawnPoint.position, checkRadius);

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
        foreach (Transform spawnPoint in spawnPoints)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(spawnPoint.position, checkRadius);
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    public Teams GetTeam()
    {
        return team;
    }
}
