using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake2 : MonoBehaviour
{
    private Vector2 diraction = Vector2.right;

    private List<Transform> _segments = new List<Transform>();

    public Transform segementPrefab;

    [SerializeField] private int initialSize = 3;

    private void Start()
    {

        StartCoroutine(DemoCoroutine());
        ResetState();
    }

    //private float speed = 1f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            diraction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            diraction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            diraction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            diraction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3
            (
            Mathf.Round(this.transform.position.x) + diraction.x,
            Mathf.Round(this.transform.position.y) + diraction.y,
              0.0f);
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segementPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segementPrefab));
        }

        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("food"))
        {
            Grow();
        }
        else if (other.tag == "Obstacle" || other.tag == "snake 2")
        {
            ResetState();
        }
    }

    private IEnumerator DemoCoroutine()
    {
        WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(10);
        yield return waitForSecondsRealtime;
    }
}


