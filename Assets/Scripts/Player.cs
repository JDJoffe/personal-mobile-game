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
    public Rigidbody bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        #region gun
        float x = Screen.width / 2;
        float y = Screen.height / 2;

        var gunray = mainCam.ScreenPointToRay(new Vector3(x, y, 0));

        shootTimer += Time.deltaTime;
        if (shootTimer > 1f && canShoot == true && Input.GetKey(KeyCode.Mouse0))
        {
            Rigidbody clone = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
            var bulletray = mainCam.ScreenPointToRay(new Vector3(x, y, 0));

            clone.velocity = bulletray.direction * 40;
            shootTimer = 0;
        }
        #endregion
    }
}
