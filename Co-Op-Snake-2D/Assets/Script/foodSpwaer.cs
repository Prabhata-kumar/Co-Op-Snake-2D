using UnityEngine;
using System.Collections;

public class foodSpwaer : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject foodPrefab2;
    public GameObject foodPrefab3;

    public BoxCollider2D gridArea;

    void Start()
    {
        InvokeRepeating("Spawn", 2, 4);
        InvokeRepeating("RandomizePositionForPoisen", 1, 31);
        InvokeRepeating("SuperPower", 1, 40);
    }
    void Spawn()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        // Instantiate the food at (x, y)
        Instantiate(foodPrefab,new Vector2(x, y),Quaternion.identity); // default rotation
    }
    public void RandomizePositionForPoisen()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        Instantiate(foodPrefab2, new Vector2(x, y), Quaternion.identity);
    }
    public void RandomizePositionForPowerUp()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        Instantiate(foodPrefab2, new Vector2(x, y), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "snake 1" || other.tag == "snake 2")
        {
            Destroy(foodPrefab);
        }
        if (other.tag == "snake 1" || other.tag == "snake 2")
        {
            Destroy(foodPrefab2);
        }
        if (other.tag == "snake 1" || other.tag == "snake 2")
        {
            Destroy(foodPrefab3);
        }
    }
}