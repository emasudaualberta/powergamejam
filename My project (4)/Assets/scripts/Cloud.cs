using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> textures = new List<Sprite>();
    SpriteRenderer sr;
    void Start()
    {
       sr = GetComponent<SpriteRenderer>();
       sr.sprite = textures[Random.Range(0,textures.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        float vert = this.transform.localPosition.y;
        this.transform.localPosition += (new Vector3(vert*0.001f,0.01f,0f))*Time.deltaTime*100f;
        sr.color = new Color(0.3f,0.3f,0.3f,(1.0f - vert/10f ));
        if (this.transform.localPosition.y > 10) {Destroy(this.gameObject);}
        
    }
}
