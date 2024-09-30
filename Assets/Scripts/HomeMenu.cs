using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public GameObject[] Buttons;
    public int ButtonActiveIndex = 0;

    public void StartGame()
    {
       SceneManager.LoadScene("Game");
    }
}

