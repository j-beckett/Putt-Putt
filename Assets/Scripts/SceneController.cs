using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) { 
            enemy = Instantiate(enemyPrefab) as GameObject; 
            enemy.transform.position = spawnPoint;
            float angle = Random.Range(0, 360); 
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}
