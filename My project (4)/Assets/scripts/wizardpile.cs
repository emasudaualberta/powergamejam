using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardpile : MonoBehaviour
{


    public int wizards = 1;
    public int powerPerWiz = 10;
    int combatpower;
    public GameObject SpawnedEnitity;
    // Start is called before the first frame update
    void Start()
    {
        combatpower = wizards*powerPerWiz;
    }

    // Update is called once per frame
    void Update()
    {
        AddWizard();
    }
    
    void AddWizard() {
    wizards = wizards+1;
    GameObject newwiz = Instantiate(SpawnedEnitity, this.transform);
    Vector2 newpos = Random.insideUnitCircle;
    newwiz.transform.localPosition = new Vector3(newpos.x,newpos.y,0);
    combatpower = wizards*powerPerWiz;
    }
}
