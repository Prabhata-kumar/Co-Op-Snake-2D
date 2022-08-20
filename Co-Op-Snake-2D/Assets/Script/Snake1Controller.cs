using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake1Controller : MonoBehaviour
{
    public Transform segementPrefab;

    private Vector2 diraction = Vector2.right;

    private List<Transform> _segments = new List<Transform>();

    private ScoreController scoreControllerObject;

    private int JustValue = 0;

    [SerializeField] private int initialSize = 3;

    private void Start()
    {
        ResetState();
    }

    //private float speed = 1f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            diraction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            diraction = Vector2.down;    
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            diraction = Vector2.left ;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            diraction = Vector2.right ;
        }
    }

    private void FixedUpdate()             //Help it to attach the segement's position on in a sequence
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i-1].position;
        }
        this.transform.position = new Vector3
            (Mathf.Round(this.transform.position.x)+ diraction.x,Mathf.Round(this.transform.position.y)+ diraction.y,0.0f);
    }
    
    private void Grow()
    {
        Transform segment = Instantiate(this.segementPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);                     //Adding neqw segement's
    }

    private void Loss() 
    {
        if (_segments.Count == 1)   //if body is too short
        {
            ResetState();
        }
        else                        
        {
            Destroy(_segments[_segments.Count - 1].gameObject);
            _segments.RemoveAt(_segments.Count - 1);   //If one is doe't work 2nd will work
        }
    }
    public void ResetState()
    {
        for (int i =1;i < _segments.Count; i++)
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
        if (other.tag == "food")//to gain the body
        {         
                Grow();
                Destroy(other.gameObject);
        }
        else if (other.tag == "Obstacle" ) //Same tag to body also
        {
            ResetState();
        }
        else if(other.tag == "Posion")//for loss the body 
        {
            Loss();
            Destroy(other.gameObject);
        }
    }

}


  