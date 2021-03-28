using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    //Dead enemy stats
    public float speed;
    public int health; 
    public int damage;
    public float shootTime;
    public float shootSpeed;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHandler>().health = health;
            other.gameObject.GetComponent<PlayerHandler>().speed = speed;
            other.gameObject.GetComponent<PlayerHandler>().damage = damage;
            other.gameObject.GetComponent<PlayerHandler>().bulletSpeed = shootSpeed;
            other.gameObject.GetComponent<PlayerHandler>().level = level;
            Debug.Log("Stats changed.");
            Destroy(gameObject);
        }
    }
}
