using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public int weaponswitch = 0;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool onGrass = false;

    public GameObject BombProjectile;
    public GameObject OrbProjectile;
    [SerializeField] private GameObject currentTower;

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
        // get WASD input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
        if (movement.x > 0)
            transform.localScale = new Vector3(3, 3, 1);
        else if (movement.x < 0)
            transform.localScale = new Vector3(-3, 3, 1);
    }
    void Update()
    {
        //r to shoot bombs
        Movement();
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (weaponswitch == 0)
            {
                weaponswitch = 1;
            } else if (weaponswitch == 1)
            {
                weaponswitch = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (weaponswitch == 0)
            {
                InstantiateBomb();
            } else if (weaponswitch == 1)
            {
                InstantiateOrb();
            }
        }
        if(Input.GetKeyDown(KeyCode.F) && onGrass == true)
        {
            GameObject tower = Instantiate(currentTower, transform.position, Quaternion.identity);
        }
    }
    void InstantiateBomb()
    {
        //get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        //turn position into vector
        Vector2 direction = (mousePos - transform.position).normalized;
        //create bombs an shoot them in direction
        GameObject bomb = Instantiate(BombProjectile, transform.position, Quaternion.identity);
        Rigidbody2D rbProjectile = bomb.GetComponent<Rigidbody2D>();
        if (rbProjectile != null)
        {
            rbProjectile.velocity = direction * 6;
        }
    }
    void InstantiateOrb()
    {
        //get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        //turn position into vector
        Vector2 direction = (mousePos - transform.position).normalized;
        //create orb an shoot them in direction
        GameObject orb = Instantiate(OrbProjectile, transform.position, Quaternion.identity);
        Rigidbody2D rbProjectile = orb.GetComponent<Rigidbody2D>();
        if (rbProjectile != null)
        {
            rbProjectile.velocity = direction * 9;
        }
    }
    void FixedUpdate()
    {
        // Apply movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log(target.transform.name);
        onGrass = true;
    }

    void OnTriggerExit2D(Collider2D target)
    {
        Debug.Log(target.transform.name);
        onGrass = false;
    }

}