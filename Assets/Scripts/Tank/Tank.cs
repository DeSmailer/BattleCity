using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Hull hull;
    public Tower tower;
    public Cannon cannon;

    public float pickUpRadius;

    public GameObject droppedModule;

    public Teams team;
    public void PickUp()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, pickUpRadius);

        foreach (Collider2D hitCollider in hitColliders)
        {
            IPickUp equipament = hitCollider.GetComponent(typeof(IPickUp)) as IPickUp;
            if (equipament != null)
            {
                print("поднял" + equipament.PickUp("red"));
                var qwe = equipament.PickUp("red");
                switch (qwe.ModuleType)
                {
                    case ModulesTypes.Hull:
                        hull.Equip(equipament.PickUp("red"));
                        break;

                    case ModulesTypes.Tower:
                        hull.Equip(equipament.PickUp("red"));
                        break;

                    case ModulesTypes.Cannon:
                        hull.Equip(equipament.PickUp("red"));
                        break;
                }
            }
        }
    }

    public void Drop()  
    {
        int rand = Random.Range(0, 1);
        print(rand);
        GameObject drop = Instantiate(droppedModule, transform.position, Quaternion.identity);
        switch (rand)
        {
            case 0:
                drop.GetComponent<DroppedModule>().Drop(hull.moduleData);
                break;

            case 1:
                drop.GetComponent<DroppedModule>().Drop(tower.moduleData);
                break;

            case 2:
                drop.GetComponent<DroppedModule>().Drop(cannon.moduleData);
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);
    }

}
