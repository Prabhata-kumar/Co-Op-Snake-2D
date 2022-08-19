using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpwaer : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public Transform foodPrefab1;
    public Transform foodPrefab2;
    public Transform foodPrefab3;
    private void Update()
    {
        //RandomizePosition();
        InvokeRepeating("RandomizePositionForFood", 3, 4);
        InvokeRepeating("RandomizePositionForPoisen", 3, 10);
        InvokeRepeating("SuperPower", 3, 20);
    }

    public void RandomizePositionForFood()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        Instantiate(foodPrefab1,new Vector2(x, y),Quaternion.identity);
      
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
            RandomizePositionForFood();
            Destroy(foodPrefab1);
        }
        if (other.tag == "snake 1" || other.tag == "snake 2")
        {
            RandomizePositionForPoisen();
            Destroy(foodPrefab2);
        }
        if (other.tag == "snake 1" || other.tag == "snake 2")
        {
            RandomizePositionForPowerUp();
            Destroy(foodPrefab2);
        }
    }
}
