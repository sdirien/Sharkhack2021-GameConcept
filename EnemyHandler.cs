using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    //Empty Rigidbody2D component to store enemy RigidBody2D in 
    Rigidbody2D body;
    //Empty GameObject player to represent the player character
    GameObject player;
    //Empty Transform to hold player's transform coordinates--their location
    Transform playerTransform;

    //Reference to star object
    public Rigidbody2D starObject;

    //Reference to bullet projectile
    public Rigidbody2D projectile;

    private float timer = 0.0f;
    public float shootTime = 1f; //How often the enemy shoots
    public float shootSpeed = 5f; //How fast the enemy bullets go

    //Distance between enemy and player
    private float range;

    public int level;
    //how fast the enemy moves
    public float speed;
    //the enemy's health
    public int health;
    public int baseHealth;
    //the enemy's damage 
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        health = baseHealth;
        //Find enemy body
        body = GetComponent<Rigidbody2D>();
        //Find player
        player = GameObject.Find("Player");
        //Get player transform
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();

        //Find distance between enemy and player
        range = Vector2.Distance(body.position, playerTransform.position);

        //Determine enemy actions
        if (range < 2)
        {
            //Fire at player
            Fire();
        }
        else if (range < 10 && range > 2 && player.GetComponent<PlayerHandler>().health >= health/2)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        } 
    }

    void Fire()
    {
        timer += Time.deltaTime;
        if (timer > shootTime)
        {
            //Make bullet
            Rigidbody2D bullet = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
            //Aim bullet
            Vector2 direction = playerTransform.position - transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * shootSpeed;
            bullet.GetComponent<Projectile>().shooter = gameObject;
            bullet.GetComponent<Projectile>().damage = damage;
            timer = 0;
        }
    }

    void Die()
    {
        if (health <= 0)
        {
            //Create star object
            Rigidbody2D star = Instantiate(starObject, transform.position, transform.rotation) as Rigidbody2D;
            //Set enemy stats to star
            star.GetComponent<StarHandler>().health = baseHealth;
            star.GetComponent<StarHandler>().damage = damage;
            star.GetComponent<StarHandler>().speed = speed;
            star.GetComponent<StarHandler>().shootTime = shootTime;
            star.GetComponent<StarHandler>().shootSpeed = shootSpeed;
            //Kill enemy gameobject
            gameObject.SetActive(false);
        }
    }
}
