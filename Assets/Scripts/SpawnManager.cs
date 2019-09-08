using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Var")]
    public float spawnTimer;
    
    [Header("GameObjects")]
    public GameObject enemyPrefab;
    public Transform[] wayPoints;
    Enemies enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Enemy = GameObject.Find("Enemy");
         enemyScript = Enemy.GetComponent<Enemies>();
        wayPoints = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.enemyAlive == false)
        {
            int waypointNum = Random.Range(1, 5);
            Instantiate(enemyPrefab, wayPoints[waypointNum].transform.position, Quaternion.identity);
            enemyScript.enemyAlive = true;
        }
    }
}
