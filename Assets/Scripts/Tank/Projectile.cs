using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public Vector3 direction;

    private void Start()
    {
        direction = Vector3.right;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
            print("столкнулись");
            Destroy(this.gameObject);
    }
}
