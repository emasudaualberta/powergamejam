using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castlespawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject enemyOne;
    public GameObject enemyTwo;
     float gameSpeed;
    public string wave= "1..1..1..111";
    public point.direction facing;
    void Awake()
    {
        gameSpeed = gameManager.Instance.gamespeed;
        StartCoroutine(ReadEnemyWave());
    }

    IEnumerator ReadEnemyWave()
    {
        yield return new WaitForSecondsRealtime(gameSpeed);

        foreach(char action in wave)
        {
            if (action == '.')
            {
                yield return new WaitForSecondsRealtime(gameSpeed);
            }
            else
            {
                yield return new WaitForSecondsRealtime(gameSpeed);
                instantiateEnemy(action);
            }
        }
        Debug.Log("end");

    }


    void instantiateEnemy(char enemy)
    {
        GameObject newEnemy=null;
        if (enemy == '1')
        {
           newEnemy = Instantiate(enemyOne);

        }
        else if (enemy == '2')
        {
            newEnemy = Instantiate(enemyTwo);
        }
        if (newEnemy != null)
        {
            newEnemy.GetComponent<enemyMover>().changeDirection(facing);
            newEnemy.transform.position = transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
