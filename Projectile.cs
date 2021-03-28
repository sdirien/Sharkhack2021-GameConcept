using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifespan = 3f;

    private Rigidbody2D projectile;
    public GameObject shooter; //the object shooting the bullet

    public float damage;

    void Awake()
    {
        projectile = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.tag != gameObject.tag && shooter.gameObject.tag == "Player")
        {
            Debug.Log("Hit!");
            other.gameObject.GetComponent<EnemyHandler>().health -= 2;
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player" && other.gameObject.tag != gameObject.tag && shooter.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit!");
            other.gameObject.GetComponent<PlayerHandler>().health -= 2;
            Destroy(gameObject);
        }
    }
}
