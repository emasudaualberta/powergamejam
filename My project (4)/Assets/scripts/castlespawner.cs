using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castlespawner : MonoBehaviour
{
    // Start is called before the first frame update
    public enemyWave enemyWave;
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public float gameSpeed;
    public string wave= "1..1..1..111";
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
                instantiateEnemy(action);
            }
        }
        Debug.Log("end");

    }


    void instantiateEnemy(char enemy)
    {
        if (enemy == '1')
        {
           Instantiate(enemyOne);
        }
        else if (enemy == '2')
        {
            Instantiate(enemyTwo);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
