using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    public Vector2 _direction;
    private List<GameObject> _segments = new List<GameObject>();
    [SerializeField] GameObject _segmentPrefab;
    [SerializeField] Transform _segmentParent;

    private void Start()
    {
        Starting();
        _segments.Add(this.gameObject);

        CreateSegment();
        _segments[1].gameObject.SetActive(false);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hor"))
        {
            this.gameObject.transform.position = new Vector2(-transform.position.x, transform.position.y);
        }

        else if (collision.gameObject.CompareTag("up"))
        {
            this.gameObject.transform.position = new Vector2(transform.position.x, -2.85f);
        }

        else if (collision.gameObject.CompareTag("down"))
        {
            this.gameObject.transform.position = new Vector2(transform.position.x, 4.8f);
        }

        else if (collision.gameObject.CompareTag("self"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        Mover();
        MoveSegments();
    }

    public void CreateSegment()
    {
        GameObject newSegment = Instantiate(_segmentPrefab, _segmentParent);
        newSegment.transform.position = _segments[_segments.Count - 1].transform.position;
        _segments.Add(newSegment);
    }

    void MoveSegments()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].transform.position = _segments[i - 1].transform.position;
        }
    }


    private void Starting()
    {
        _direction = Vector2.right;
        Time.timeScale = 0.1f;
    }

    void Mover()
    {
        this.transform.position = new Vector2(this.transform.position.x + _direction.x * 0.2f, this.transform.position.y + _direction.y * 0.2f);
    }

}
