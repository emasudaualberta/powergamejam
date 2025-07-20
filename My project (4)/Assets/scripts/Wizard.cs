using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public GameObject BombProjectile;
    public float projectileSpeed = 6f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("afgsh");
        }
    }

    void Movement()
    {
        // Get WASD input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
        if (movement.x > 0)
            transform.localScale = new Vector3(3, 3, 1);
        else if (movement.x < 0)
            transform.localScale = new Vector3(-3, 3, 1);
    }
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.R))
        {
            InstantiateBomb();
        }
    }
    void InstantiateBomb()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 direction = (mousePos - transform.position).normalized;
    
        GameObject Projectile = Instantiate(BombProjectile, transform.position, Quaternion.identity);
        Rigidbody2D rbProjectile = Projectile.GetComponent<Rigidbody2D>();
        if (rbProjectile != null)
        {
            rbProjectile.velocity = direction * projectileSpeed;
        }
    }
    void FixedUpdate()
    {
        // Apply movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}