using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    [SerializeField] float min_x, max_x, min_y, max_y;
    [SerializeField] SnakeController _snake;

    private void Start()
    {
        CreateAppleInRandomLocation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            CreateAppleInRandomLocation();
            _snake.CreateSegment();
        }
    }

    private void CreateAppleInRandomLocation()
    {
        transform.position = new Vector2(
                    Mathf.Round(Random.Range(min_x, max_x)) + 0.2f,
                    Mathf.Round(Random.Range(min_y, max_y)) + 0.2f
                    );
    }
}
