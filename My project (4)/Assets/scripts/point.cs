using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    // Start is called before the first frame update
    public enum direction
    {
        North,
        South,
        East,
        West,
    }

    public bool isEnd= false;
    public direction sendDirection;
    
    SpriteRenderer spriteRenderer;
    void Start()
    {
        
        switch (sendDirection){

            case direction.North:
                transform.eulerAngles = new Vector3(0,0,180);
                
                break;
            case direction.South:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case direction.East:
                transform.eulerAngles = new Vector3(0, 0, 90);
                break;
            case direction.West:
                transform.eulerAngles = new Vector3(0, 0, 270);
                break;

        }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public direction giveDirection()
    {
        return sendDirection;
    }


}
