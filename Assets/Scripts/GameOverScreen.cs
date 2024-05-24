using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text totalPoinsText;
    public AudioManager audioManager;

    public void Setup (int score)
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        totalPoinsText.text = score.ToString() + " POINTS";
        AudioSource gameMusic = GameObject.FindGameObjectWithTag("gameMusic").GetComponent<AudioSource>();
        audioManager.Dead();
        gameMusic.Pause();
    }

    public IEnumerator RestartWithSfx()
    {
        audioManager.ClickMenuButton();
        yield return new WaitForSecondsRealtime(0.7f);
        SceneManager.LoadScene("Game");
        Time.fixedDeltaTime = 0.25f;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        StartCoroutine(RestartWithSfx());
    }
}
