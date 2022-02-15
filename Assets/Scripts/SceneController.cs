using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private int numEnemies;
    private GameObject[] enemyArr;
    // Start is called before the first frame update
    void Start()
    {
        numEnemies = 14;

        enemyArr = new GameObject[numEnemies];
        for (int i = 0; i < numEnemies; i++)
        {
            enemyArr[i] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < numEnemies; i++)
        {
            if (enemyArr[i] == null)
            {
                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = spawnPoint;
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);

                enemyArr[i] = enemy;
            }
        }
    }
}
