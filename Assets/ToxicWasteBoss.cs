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

    [SerializeField]
    private GameObject floorAttack;

    public int numberOfAttacks = 2;
    private int switchController = 1;
    public int maxAttacks = 5; // Maximum number of attacks that can happen per attack type
    private int attackCount = 1; // Counts number of attacks, if greater than maxAttacks, increments switchController to change attack

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = 12;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastAttackTime)
        {
            switch (switchController)
            {
                case 1:
                    //Debug.Log("Case 1");
                    shoot();
                    attackCount++;
                    break;
                case 2:
                    //Debug.Log("Case 2");
                    summonFloorAttack();
                    attackCount++;
                    break;
            }

            if (attackCount > maxAttacks)
            {
                attackCount = 1;
                switchController++;
                if (switchController > numberOfAttacks)
                {
                    switchController = 1;
                }
            }
        }
        //shoot();
    
    }

    private void shoot()
    {
        //Debug.Log("Here");
        //if (Time.time > lastAttackTime)
        {
            //Debug.Log("here2");
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            SoundScript.play("Boss Projectile");
            lastAttackTime = Time.time + attackCooldown;
        }
    }

    private void summonFloorAttack()
    {
        //if (Time.time > lastAttackTime)
        {
            Instantiate(floorAttack, new Vector2(player.transform.position.x, gameObject.transform.position.y), player.transform.rotation);
            SoundScript.play("Boss Floor Attack");
            lastAttackTime = Time.time + attackCooldown;
        }
    }
}
