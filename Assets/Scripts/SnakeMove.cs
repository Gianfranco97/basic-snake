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
        segmets = new List<Transform>
        {
            transform
        };
    }

    private void IncreseSpeed()
    {
        Time.fixedDeltaTime = Time.fixedDeltaTime * 0.98f;
    }

    public void ChangeDirectionToUp()
    {
        if (!inMovin && direction != Vector2.down)
        {
            inMovin = true;
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    public void ChangeDirectionToDown()
    {
        if (!inMovin && direction != Vector2.up)
        {
            inMovin = true;
            direction = Vector2.down;
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }

    public void ChangeDirectionToLeft()
    {
        if (!inMovin && direction != Vector2.right)
        {
            inMovin = true;
            direction = Vector2.left;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    public void ChangeDirectionToRight()
    {
        if (!inMovin && direction != Vector2.left)
        {
            inMovin = true;
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
        IncreseSpeed();
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
