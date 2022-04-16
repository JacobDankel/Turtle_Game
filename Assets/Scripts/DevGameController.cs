using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevGameController : MonoBehaviour
{

    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Level_1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Level_2");
        }

        //Exiting the Game

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
