using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Var")]
    public bool canShoot = true;
    public float shootTimer;
    public float health;
    public float moveSpeed = 2f;
    [Header("Objects")]
    public Camera mainCam;
    public GameObject barrel;
    public Rigidbody bulletPrefab;
    Rigidbody player;
    // Start is called before the first frame update
    void Start()
    {
        barrel = GameObject.Find("barrel");
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region movement

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.velocity = transform.forward * moveSpeed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                player.velocity = transform.right * -moveSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.velocity = transform.forward * -moveSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                player.velocity = transform.right * moveSpeed;
            }
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
        {

        }
        #endregion
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
        // fire bullet from gun 
        if (shootTimer > 1f && canShoot == true && Input.GetKey(KeyCode.Mouse0))
        {
            // instantiate clone at barrel position
            Vector3 endOfBarrel = new Vector3(0f, 0f, +.4f);
            Rigidbody clone = Instantiate(bulletPrefab, barrel.transform.position + endOfBarrel, barrel.transform.rotation);
            //go to centre of screen
            var bulletray = mainCam.ScreenPointToRay(new Vector3(x, y, 0));
            //clone speed and direction
            clone.velocity = bulletray.direction * 40;
            Destroy(clone.gameObject, 3f);
            shootTimer = 0; // put new stuff above here so it actually runs dickhed          
        }

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
