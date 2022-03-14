using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : Interactable
{
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void Interact()
    {
        //Debug.Log("I'm here");
        SceneManager.LoadScene(nextLevel);
    }
}
