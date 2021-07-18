using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Module
{
    public override void Equip(ModuleData moduleData)
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //��������� ���� �� �������� � ������� ����������
        var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);//���� ����� �������� �� ������� � ���� � ���� �
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);//������� ����� �� ��������
    }
}


