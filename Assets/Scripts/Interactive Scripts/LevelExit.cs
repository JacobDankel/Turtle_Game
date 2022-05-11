using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : Interactable
{
    public string nextLevel;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public override void Interact()
    {
        player.GetComponent<PlayerMovement>().saveUpgrades();
        SceneManager.LoadScene(nextLevel);
    }
}
