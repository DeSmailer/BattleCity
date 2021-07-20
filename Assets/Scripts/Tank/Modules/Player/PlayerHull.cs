using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHull : Hull
{

    public delegate void ChangeHP(float HPPercent);
    public event ChangeHP Notify;

    public Slider slider;

    private void Start()
    {
        slider = GameObject.FindGameObjectWithTag("HPSlider").GetComponent<Slider>();
        DisplayHP();
    }

    public override void Equip(ModuleData moduleData)
    {
        base.Equip(moduleData);
        DisplayHP();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        DisplayHP();
    }

    private void DisplayHP()
    {
        if (slider==null)
        {
            slider = GameObject.FindGameObjectWithTag("HPSlider").GetComponent<Slider>();
        }
        slider.value = currentHP / maxHP;
    }

    public override void Move()
    {
        goHorizontal = Input.GetAxisRaw("Horizontal");
        goVertical = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(goHorizontal, goVertical).normalized;

        rb2d.velocity = moveDir * speed * Time.deltaTime;

        if (moveDir != Vector3.zero)
        {
            lookDir = new Vector3(-goVertical, goHorizontal);
            transform.parent.rotation = Quaternion.LookRotation(new Vector3(0, 0, 90), lookDir);
        }
    }
    public override void Dead()
    {
        ResultGame.Lose();
    }
}
