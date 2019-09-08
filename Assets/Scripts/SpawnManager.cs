using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Enemies
{
    [Header("Var")]
    public float spawnTimer;
    
    [Header("GameObjects")]
    public GameObject enemyPrefab;
    public Transform[] wayPoints;
    // Start is called before the first frame update
    void Start()
    {
        wayPoints = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyAlive == true)
        {
            int waypointNum = Random.Range(1, 5);
            Instantiate(enemyPrefab, wayPoints[waypointNum].transform.position, Quaternion.identity);
            enemyAlive = true;
        }
    }
}
