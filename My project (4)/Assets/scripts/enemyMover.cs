using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMover : MonoBehaviour
{
    
    point.direction currentdirection;
    int xdir=1;
    int ydir =0;
    int speed=5;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("as;df");
        point movepoint = collision.gameObject.GetComponent<point>();
        if ( movepoint!= null)
        {

            if (movepoint.isEnd) {
                gameManager.Instance.hp -= 1;
                //Debug.Log(gameManager.Instance.hp);
                Destroy(gameObject);
            }
            changeDirection(movepoint.sendDirection);
            //Debug.Log(collision.gameObject.name);

        }
       


    }
    public void changeDirection(point.direction newDirection)
    {
        switch (newDirection)
        {

            case point.direction.North:
                //transform.eulerAngles = new Vector3(0, 0, 180);
                xdir = 0; ydir = 1;
                break;
            case point.direction.South:
                //transform.eulerAngles = new Vector3(0, 0, 0);
                xdir = 0; ydir = -1;
                break;
            case point.direction.East:
                //transform.eulerAngles = new Vector3(0, 0, 90);
                xdir = 1; ydir = 0;
                break;
            case    point.direction.West:
                //transform.eulerAngles = new Vector3(0, 0, 270);
                xdir = -1; ydir = 0;
                break;

        }


    }
   

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xdir * Time.deltaTime*speed, ydir * Time.deltaTime * speed,0);
    }
}
