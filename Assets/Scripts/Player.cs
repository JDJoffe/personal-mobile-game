﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Var")]
    public JoyStick movementJoystick;
     public float runSpeed = 3.5f, horizontalRotateSpeed = 100f, verticalRotateSpeed = 50f;
     Vector3 rot;
    public bool isPC;
    public float health;
    public float rotateSpeed = 1f;
    public float moveSpeed = 2f;
    Vector2 screen;
    [Header("Objects")]
    public Camera mainCam;
    public GameObject barrel;
    public Rigidbody bulletPrefab;
    CharacterController player;
    Vector3 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        barrel = GameObject.Find("barrel");
        player = GetComponent<CharacterController>();
       if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
       {
            isPC = true;
       }
       else { isPC = false; }
    }

    // Update is called once per frame
    void Update()
    {  
        if (isPC == true)
        {
            MovePC();        
            gunPC();      
        }
        if (isPC == false)
        {
           movePhone();
       }
    }
    #region movement
    private void MovePC()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDir *= moveSpeed;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 2;
        }
        else { moveSpeed = 3f; }
        moveDir = transform.TransformDirection(moveDir);
        player.Move(moveDir * Time.deltaTime);

    }
    void movePhone()
    {
        
        transform.position += transform.TransformDirection(new Vector3(movementJoystick.Horizontal, 0f, movementJoystick.Vertical) * runSpeed * Time.deltaTime);
    }
    #endregion
    #region gun
     void gunPC()
    {
        float x = Screen.width / 2;
        float y = Screen.height / 2;


        //  RaycastHit hit;
        //fire a ray at centre of screen
        //  if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        //  {
        //   var gunray = mainCam.ScreenPointToRay(Vector3.forward);
        //gun.transform.LookAt(gunray.direction);
        //  }


        // fire bullet from gun 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // instantiate clone at barrel position
            Vector3 endOfBarrel = transform.forward * .5f;
            Rigidbody clone = Instantiate(bulletPrefab, barrel.transform.position + endOfBarrel, barrel.transform.rotation);
            //go to centre of screen
            var bulletray = mainCam.ScreenPointToRay(new Vector3(x, y, 0));
            //clone speed and direction
            clone.velocity = bulletray.direction * 40;
               
        }
    }
    #endregion
    public void gunPhone()
    {

            Debug.Log("imshooting");
         float x = Screen.width / 2;
        float y = Screen.height / 2;
         // instantiate clone at barrel position
            Vector3 endOfBarrel = transform.forward * .5f;
            Rigidbody clone = Instantiate(bulletPrefab, barrel.transform.position + endOfBarrel, barrel.transform.rotation);
            //go to centre of screen
            var bulletray = mainCam.ScreenPointToRay(new Vector3(x, y, 0));
            //clone speed and direction
            clone.velocity = bulletray.direction * 40;
             
           
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.blue;
        //var hit = mainCam.ScreenPointToRay(Vector3.forward);
        //Gizmos.DrawRay(hit);
        //Debug.DrawRay(gun.transform.position, Vector3.forward);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            health--;
        }
    }
    private void OnGUI()
    {
        screen.x = Screen.width;
        screen.y = Screen.height;

        GUI.Box(new Rect(4f * screen.x, .5f * screen.y, 3f * screen.x, .275f * screen.y), health.ToString());


    }
}
