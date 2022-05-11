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
    private float vulnerabilityPeriod;

    private float lastAttackTime, lastMeleeAttackTime;
    private float lastVulnerability;

    [SerializeField]
    private GameObject floorAttack;
    [SerializeField]
    private GameObject radioactiveRainCloud;
    [SerializeField]
    private GameObject rainCloudSpawn;
    [SerializeField]
    private GameObject meleeTrigger;
    [SerializeField]
    private GameObject healthRefill;
    [SerializeField]
    private Transform healthRefillSpawnPoint;

    public int numberOfAttacks = 3;
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
        vulnerabilityPeriod = (attackCooldown * 5f)*0.5f;
        rainCloudSpawn = GameObject.Find("Rain Cloud Spawn");
        healthRefillSpawnPoint = GameObject.Find("Health Refill Spawn Point").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastAttackTime && Time.time > lastVulnerability && player != null)
        {
            switch (switchController)
            {
                case 1:
                    //Debug.Log("Case 1" + switchController);
                    shoot();
                    attackCount++;
                    break;
                case 2:
                    //Debug.Log("Case 2" + switchController);
                    summonFloorAttack();
                    attackCount++;
                    break;
                case 3:
                    //Debug.Log("Case 3" + switchController);
                    summonRadioactiveRain();
                    attackCount += maxAttacks;
                    break;
            }

            if (attackCount > maxAttacks)
            {
                
                attackCount = 1;
                switchController++;
                if (switchController == 1)
                {
                    Instantiate(healthRefill, healthRefillSpawnPoint.position, healthRefillSpawnPoint.rotation);
                }
                lastVulnerability = Time.time + vulnerabilityPeriod;
                if (switchController > numberOfAttacks)
                {
                    switchController = 1;
                }
                if (switchController == 1)
                {
                    Instantiate(healthRefill, healthRefillSpawnPoint.position, healthRefillSpawnPoint.rotation);
                }
            }
        }
        if (Time.time !> lastVulnerability && Time.time > lastMeleeAttackTime && meleeTrigger.GetComponent<BoxCollider2D>().IsTouchingLayers(playerLayer))
        {
            Instantiate(floorAttack, meleeTrigger.transform.position, meleeTrigger.transform.rotation);
            SoundScript.play("Boss Floor Attack");
            lastMeleeAttackTime = Time.time + attackCooldown;
        }
    }

    private void shoot()
    {
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

    private void summonRadioactiveRain()
    {
        Instantiate(radioactiveRainCloud, rainCloudSpawn.transform.position, rainCloudSpawn.transform.rotation);
        //SoundScript.play("Boss Floor Attack");
        lastAttackTime = Time.time + attackCooldown;
    }
}
