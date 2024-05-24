using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuButton, getCoin, dead;

    public void ClickMenuButton()
    {
        audioSource.clip = menuButton;
        audioSource.Play();
    }

    public void Dead() {
        audioSource.clip = dead; 
        audioSource.Play();
    }

    public void GetCoin()
    {
        audioSource.clip = getCoin;
        audioSource.Play();
    }
}
