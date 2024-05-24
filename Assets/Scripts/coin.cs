using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioManager audioManager;

    private void generateNewCoin()
    {

        GameObject newCoin = GameObject.Instantiate(gameObject);

        newCoin.transform.position = new Vector3(Random.Range(-18, 18), Random.Range(-9, 9), 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("snake head")) {
            audioManager.GetCoin();
            generateNewCoin();
            Destroy(gameObject);
        }
    }
}
