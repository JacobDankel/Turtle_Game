using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSc : MonoBehaviour
{

    public GameObject player;

    public void RestartButton()
    {
        SceneManager.LoadScene("Level_1");

    }

    public void ExitButton()
    {
        Destroy(player);
        SceneManager.LoadScene("Main Menu");
    }

}
