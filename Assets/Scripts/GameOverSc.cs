using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSc : MonoBehaviour
{
    public string levelToRestart;
    public GameObject player;

    public void RestartButton()
    {
        SceneManager.LoadScene(levelToRestart);

    }

    public void ExitButton()
    {
        Destroy(player);
        SceneManager.LoadScene("Main Menu");
    }

}
