using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip playerAttack, playerGotHit, playerJump, enemyGotHit, itemPickup;
    public static AudioClip bossFloorAttack, bossProjectile;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerAttack = Resources.Load<AudioClip>("slash");
        playerGotHit = Resources.Load<AudioClip>("smack");
        playerJump = Resources.Load<AudioClip>("jump");
        enemyGotHit = Resources.Load<AudioClip>("Enemy Hit alt");
        itemPickup = Resources.Load<AudioClip>("Item Pickup");
        bossFloorAttack = Resources.Load<AudioClip>("Boss Floor Attack");
        bossProjectile = Resources.Load<AudioClip>("Boss Projectile");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void play (string audio)
    {
        switch (audio)
        {
            case "Player Attack":
                audioSource.PlayOneShot(playerAttack);
                break;
            case "Player Got Hit":
                audioSource.PlayOneShot(playerGotHit);
                break;
            case "Player Jump":
                audioSource.PlayOneShot(playerJump);
                break;
            case "Enemy Got Hit":
                audioSource.PlayOneShot(enemyGotHit);
                break;
            case "Item Pickup":
                audioSource.PlayOneShot(itemPickup);
                break;
            case "Boss Floor Attack":
                audioSource.PlayOneShot(bossFloorAttack);
                break;
            case "Boss Projectile":
                audioSource.PlayOneShot(bossProjectile, .3f);
                break;
        }
    }
}
