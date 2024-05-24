using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SnakeMove : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private bool inMovin = false;

    public int coinsCounter = 0;
    public TMP_Text scoreText;

    private List<Transform> segmets;
    public Transform segmentPrefab;

    public GameOverScreen gameOverSrcreen;

    private void Start()
    {
        segmets = new List<Transform>();
        segmets.Add(this.transform);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && direction != Vector2.right && !inMovin)
        {
            inMovin = true;
            direction = Vector2.left;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetKey(KeyCode.RightArrow) && direction != Vector2.left && !inMovin)
        {
            inMovin = true;
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow) && direction != Vector2.down && !inMovin)
        {
            inMovin = true;
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetKey(KeyCode.DownArrow) && direction != Vector2.up && !inMovin)
        {
            inMovin = true;
            direction = Vector2.down;
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }

        if (coinsCounter >= 25)
        {
            Time.fixedDeltaTime = 0.05f;
        }
        else if (coinsCounter >= 12)
        {
            Time.fixedDeltaTime = 0.08f;
        }
        else if (coinsCounter >= 6)
        {
            Time.fixedDeltaTime = 0.12f;
        }
        else if (coinsCounter >= 3)
        {
            Time.fixedDeltaTime = 0.15f;
        }
    }

    private void FixedUpdate()
    {
        for (int index = segmets.Count - 1; index > 0; index--)
        {
            segmets[index].position = segmets[index - 1].position;
        }

       transform.position = new Vector3(
            Mathf.Round(transform.position.x) + direction.x,
            Mathf.Round(transform.position.y) + direction.y, 
            0.0f
        );

        inMovin = false;
    }

    private void Grow ()
    {
        coinsCounter++;
        scoreText.text = coinsCounter.ToString();

        Transform segment = Instantiate(segmentPrefab);
        segment.position = segmets[segmets.Count - 1].position;
        segmets.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("obstacle"))
        {
           scoreText.text = "";
           gameOverSrcreen.Setup(coinsCounter);
        }

        if (collider.CompareTag("coin"))
        {
            Grow();
        }
    }
}
