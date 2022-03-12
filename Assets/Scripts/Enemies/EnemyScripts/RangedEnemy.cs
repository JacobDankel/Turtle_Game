using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyClass
{
    [SerializeField]
    private Transform projectileSpawn;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float attackCooldown = .5f;

    private float lastAttackTime; // Time.time + attackCooldown
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
        shoot();
    }

    private void FixedUpdate()
    {
        moveRB();
    }

    private void shoot()
    {
        if (seesPlayer() && (Time.time > lastAttackTime))
        {
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            lastAttackTime = Time.time + attackCooldown;
        }
    }
}
