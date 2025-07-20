using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : MonoBehaviour
{
    private int maxMana = 20;
    private int mana = 20;
    public int weaponswitch = 0;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool onGrass = false;

    public GameObject TargetProjectile;
    public GameObject BombProjectile;
    public GameObject OrbProjectile;
    [SerializeField] private GameObject currentTower;
    [SerializeField] private GameObject[] validTowers;
    private int towerIndex = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("afgsh");
        }
        changetowerui();
        changeGunUI();
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
        if(Input.GetKeyDown(KeyCode.V))
        {
            if (weaponswitch == 0)
            {
                weaponswitch = 1;
            } else if (weaponswitch == 1)
            {
                weaponswitch = 2;
            } else if (weaponswitch == 2)
            {
                weaponswitch = 0;
            }
            changeGunUI();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (weaponswitch == 0)
            {
                InstantiateBomb();
            } else if (weaponswitch == 1)
            {
                InstantiateOrb();
            } else if (weaponswitch == 2)
            {
                InstantiatePlane();
            }
        }
        if(Input.GetKeyDown(KeyCode.F) && onGrass == true)
        {
            int towerMana = currentTower.GetComponent<wizardpile>().GetMana();
            if(towerMana <= mana)
            {
                GameObject tower = Instantiate(currentTower, transform.position, Quaternion.identity);
                this.mana -= towerMana;
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(towerIndex <= 0)
            {
                towerIndex = validTowers.Length - 1;
            } else {
                towerIndex -= 1;
            }
            
            currentTower = validTowers[towerIndex];
            changetowerui();
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            if(towerIndex >= (validTowers.Length - 1))
            {
                towerIndex = 0;
            } else {
                towerIndex += 1;
            }
            currentTower = validTowers[towerIndex];
            changetowerui();
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
    void InstantiatePlane()
    {
        //get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        //create target an shoot them in direction
        GameObject Target = Instantiate(TargetProjectile, mousePos, Quaternion.identity);
        Rigidbody2D rbProjectile = Target.GetComponent<Rigidbody2D>();
        if (rbProjectile != null)
        {
            rbProjectile.velocity = Vector2.zero;
        }
    }
    void FixedUpdate()
    {
        // Apply movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.transform.name == "Tilemap")
        {
            onGrass = true;
        }  
    }

    void OnTriggerExit2D(Collider2D target)
    {
        Debug.Log(target.transform.name);
        onGrass = false;
    }

    public int GetMana()
    {
        return this.mana;
    }

    public int GetMaxMana()
    {
        return this.maxMana;
    }
    public GameObject getCurrentTower()
    {
        return this.currentTower;
    }

    void changetowerui()
    {
        GameObject image = GameObject.FindGameObjectWithTag("towerimage");
        image.GetComponent<Image>().sprite = currentTower.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    void changeGunUI()
    {
        GameObject image = GameObject.FindGameObjectWithTag("gunUI");

        if (weaponswitch == 0)
        {
            image.GetComponent<Image>().sprite = BombProjectile.GetComponentInChildren<SpriteRenderer>().sprite;
        }
        else if (weaponswitch == 1)
        {
            image.GetComponent<Image>().sprite = OrbProjectile.GetComponentInChildren<SpriteRenderer>().sprite;
        }
        else if (weaponswitch == 2)
        {
            image.GetComponent<Image>().sprite = TargetProjectile.GetComponentInChildren<SpriteRenderer>().sprite;
        }
    }
}