using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicWasteBoss : EnemyClass
{
    [SerializeField]
    private Transform projectileSpawn;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float attackCooldown = .5f;

    private float lastAttackTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    private void shoot()
    {
        //Debug.Log("Here");
        if (Time.time > lastAttackTime)
        {
            //Debug.Log("here2");
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            lastAttackTime = Time.time + attackCooldown;
        }
    }
}
