using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSc : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Level_1");

    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
