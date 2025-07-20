using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackingbullet : MonoBehaviour
{

    public GameObject trackingObject;
    Vector3 lastpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setTarget(GameObject target)
    {
        trackingObject = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (trackingObject != null)
        {
            lastpos = trackingObject.transform.position;

        }
        Debug.Log("asdfa");
        transform.position = Vector3.MoveTowards(transform.position, lastpos, 6 * Time.deltaTime);
    }
}
