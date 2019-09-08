using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("var")]
    public float enemyHealth = 15;
    public bool enemyAlive;
    public float attackTimer;
    [Header("GameObjects")]   
    public GameObject enemy;
    public GameObject face1;
    public GameObject face2;
    public GameObject face3;
    public Rigidbody enemyBullet;
    public Camera enemyCam;
  
    private void Awake()
    {
        DontDestroyOnLoad(enemy);
    }
    // Start is called before the first frame update
    void Start()
    {
       
        //Attack();
        enemyCam = GameObject.Find("EnemyCam").GetComponent<Camera>();
    }
  
    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= 2)
        {
            Attack();
            attackTimer = 0;
        }
        //if (enemyHealth >= 0)
        //{
        // enemyAlive = false;
        //    Destroy(this.gameObject);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        enemyHealth = enemyHealth - 5;
    }
    void Attack()
    {
        Invoke("Face1To2", 1f);
        Invoke("Face2To3", 1f);
        float x = Screen.width / 2;
        float y = Screen.height / 2;
        Vector3 enemyFace = transform.forward * .5f;
        Rigidbody clone = Instantiate(enemyBullet, enemy.transform.position + enemyFace, enemy.transform.rotation);
        //go to centre of screen
        var bulletray = enemyCam.ScreenPointToRay(new Vector3(x, y, 0));
        //clone speed and direction
        clone.velocity = bulletray.direction * 40;
        Destroy(clone.gameObject, 3f);
        Invoke("Face3To1", 1f);
    }
    void Face1To2()
    {
        face1.SetActive(false);
        face2.SetActive(true);
    }
    void Face2To3()
    {
        face2.SetActive(false);
        face3.SetActive(true);
    }
    void Face3To1()
    {
        face3.SetActive(false);
        face1.SetActive(true);
    }
}
