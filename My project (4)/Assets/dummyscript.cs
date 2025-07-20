using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyscript : MonoBehaviour
{
    private bool onGrass;
    [SerializeField] private GameObject tower;
    //public Tilemap _tileset;
    //public Vector3 _tilepos;
    // Update is called once per frame
    // im going to kill myself
    void OnTriggerEnter2D(Collider2D target)
    {
        onGrass = true;
    }

    void OnTriggerExit2D(Collider2D target)
    {
        onGrass = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && onGrass == true)
        {
            GameObject new_tower = Instantiate(tower, transform.position, Quaternion.identity);
            new_tower.name = "Wizard Tower ${transform.position}";
        }
    }
}
