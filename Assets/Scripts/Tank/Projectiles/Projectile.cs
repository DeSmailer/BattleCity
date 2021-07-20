using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float shotAccuracy;
    private float damage;
    private float shotDistance;
    private Teams team;

    public float speed;
    public Vector3 direction;

    private float distanceTraveled;

    private void Update()
    {
        if (shotDistance > 0)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            distanceTraveled += speed * Time.deltaTime;

            if (distanceTraveled >= shotDistance)
            {
                Destroy(gameObject);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        IAttacable target = collision.GetComponent(typeof(IAttacable)) as IAttacable;

        if (target != null)
        {
            if (team != target.GetTeam())
            {
                float currentShotAccuracy = Random.Range(0f, 1f);
                if (shotAccuracy >= currentShotAccuracy)
                {
                    target.TakeDamage(damage);
                }
                Destroy(gameObject);
            }
        }
        else if (collision.GetComponent<Projectile>() == null)
        {
            Destroy(gameObject);
        }
    }



    public void Init(ProjectileSettings projectileSettings)
    {
        shotAccuracy = projectileSettings.shotAccuracy;
        damage = projectileSettings.damage;
        shotDistance = projectileSettings.shotDistance;
        team = projectileSettings.team;
        direction = Vector3.left;

        //print(shotAccuracy);
        //print(damage);
        //print(shotDistance);
    }
}
