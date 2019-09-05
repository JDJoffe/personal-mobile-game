using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    #region var
    [Header("Vector3")]
    public Vector3 camRotation;
    public Vector3 rotationSpeed = new Vector3(120f, 120f);
    [Header("Variables")]
    public bool cursorHidden = true;
    public float minPitch = -90f, maxPitch = 90f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (cursorHidden)
        {
            //lock and hide cursor if this is true
            //good if i ever use pause menus, maybe move into update?
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //mouse rotation               
         transform.Rotate(camRotation.x =Input.GetAxis("Mouse Y"), camRotation.y= Input.GetAxis("Mouse X"), 0) ;
        camRotation.z = 0;
        //rotate camera parent & camera
        transform.parent.localEulerAngles = new Vector3(0, rotationSpeed.y, 0);
        transform.localEulerAngles = new Vector3(rotationSpeed.x, 0, 0);
    }
}
