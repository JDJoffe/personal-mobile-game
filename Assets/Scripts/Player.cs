using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Var")]
    public bool canShoot = true;
    public float shootTimer;
    public float health;
    [Header("Objects")]
    public Camera mainCam;
    public GameObject gun;
    private GameObject barrel;
    public Rigidbody bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        barrel = GameObject.Find("barrel");
       
    }

    // Update is called once per frame
    void Update()
    {
        #region gun
        float x = Screen.width / 2;
        float y = Screen.height / 2;

        
      //  RaycastHit hit;
        //fire a ray at centre of screen
      //  if (Physics.Raycast(transform.position, Vector3.forward, out hit))
      //  {
        //   var gunray = mainCam.ScreenPointToRay(Vector3.forward);
        //gun.transform.LookAt(gunray.direction);
      //  }

            shootTimer += Time.deltaTime;
        //fire bullet from gun 
        if (shootTimer > 1f && canShoot == true && Input.GetKey(KeyCode.Mouse0))
        {
            //instantiate clone at barrel position
            Rigidbody clone = Instantiate(bulletPrefab, barrel.transform.position, barrel.transform.rotation);
            //go to centre of screen
            var bulletray = mainCam.ScreenPointToRay(new Vector3(x, y, 0));
            //clone speed and direction
            clone.velocity = bulletray.direction * 40;
            shootTimer = 0;
        }
        #endregion
        #region turning

        #endregion
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.blue;
        //var hit = mainCam.ScreenPointToRay(Vector3.forward);
        //Gizmos.DrawRay(hit);
        //Debug.DrawRay(gun.transform.position, Vector3.forward);
      
    }
}
