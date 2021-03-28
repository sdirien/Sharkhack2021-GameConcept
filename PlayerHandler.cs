using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    //Empty RigidBody2D to hold player body
    Rigidbody2D body;
    
    //Reference to bullet projectile
    public Rigidbody2D projectile;
    public float bulletSpeed = .5f;

    //Variables for movement directionals
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public int level;
    //Variables for player speed, health, damage
    public float speed = 10.0f;
    public int baseHealth = 10;
    public int health = 10;
    public int damage = 1;

    void Start()
    {
        //Set player RigidBody2D
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fire();
        }

        Die();
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void fire()
    {
        //https://answers.unity.com/questions/604198/shooting-in-direction-of-mouse-cursor-2d.html
        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;

        Rigidbody2D bullet = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
        bullet.velocity = new Vector2(shootDirection.x * bulletSpeed, shootDirection.y * bulletSpeed);

        bullet.GetComponent<Projectile>().shooter = gameObject;
        bullet.GetComponent<Projectile>().damage = damage;
    }

    void Die()
    {
        if (health <= 0)
        {
            //gameObject.SetActive(false);
            Debug.Log("Player is dead");
        }
    }

    void LevelChange()
    {

    }
}
