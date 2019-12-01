using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("var")]
    public float enemyHealth = 15;
    public int deathcounter = 0;
    public float moveSpeed = 5;
    float distance;
    [Header("GameObjects")]
    public GameObject enemy;
    public GameObject face1;
    public GameObject face2;
    public GameObject face3;
    public Camera enemyCam;
    public Transform target;
    public List<Transform> spawnPoints;
    private void Awake()
    {
        DontDestroyOnLoad(enemy);
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        enemyCam = GameObject.Find("EnemyCam").GetComponent<Camera>();
        ResetPos();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        //moveSpeed 
        transform.position = Vector3.MoveTowards(transform.position, target.position, (moveSpeed + deathcounter) * Time.deltaTime);
        distance = Vector3.Distance(transform.position, target.position);
        if (distance > 20 && distance < 30)
        {
            Face1();
        }
        if (distance > 10 && distance < 20)
        {
            Face2();
        }
        if (distance < 10)
        {
            Face3();
        }
        if (enemyHealth <= 0)
        {
            ResetPos();
            enemyHealth = 15;
            ++deathcounter;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            enemyHealth = enemyHealth - 5;
        }
        if (other.tag == "Player")
        {
            ResetPos();
        }
    }

    // these are my dumb way to do animations
    void Face1()
    {
        face3.SetActive(false);
        face2.SetActive(false);
        face1.SetActive(true);
    }
    void Face2()
    {

        face1.SetActive(false);
        face3.SetActive(false);
        face2.SetActive(true);

    }
    void Face3()
    {
        face1.SetActive(false);
        face2.SetActive(false);
        face3.SetActive(true);

    }
    public void ResetPos()
    {
        int i = Random.Range(0, 4);
        transform.position = spawnPoints[i].position;
    }
}
