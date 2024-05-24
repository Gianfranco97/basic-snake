using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeMenu : MonoBehaviour
{
    public GameObject[] Buttons;
    public int ButtonActiveIndex = 0;

    public void StartGame()
    {
       SceneManager.LoadScene("Game");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && ButtonActiveIndex > 0)
        {
            --ButtonActiveIndex;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && ButtonActiveIndex < Buttons.Length - 1)
        {
            ++ButtonActiveIndex;
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            Buttons[ButtonActiveIndex].GetComponent<Button>().onClick.Invoke();
        }

        for (int i = 0; i < Buttons.Length; ++i)
        {
            Buttons[i].GetComponent<Animator>().SetBool("active", ButtonActiveIndex == i);
        }
    }
}

