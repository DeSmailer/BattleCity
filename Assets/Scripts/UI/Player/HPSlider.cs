using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");

        print(tanks.Length);

        foreach (GameObject item in tanks)
        {
            print(item.GetComponent<Player>().hull);
            PlayerHull playerHull = (PlayerHull)item.GetComponent<Player>().hull;
            playerHull.Notify += DisplayHP;
            print(item);
            break;
        }
    }

    private void DisplayHP(float hpPercen)
    {
        print(hpPercen);

        slider.value = hpPercen;
    }
}
