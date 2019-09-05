using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    #region var
    public bool cursurHidden = true;
    public float minPitch = -80f, maxPitch = 80f;
    //vector 2 or 3 idk pick one
    public Vector3 speed = new Vector3(120f, 120f);

    private Vector3 euler; // current rotation of camera
    #endregion
    // Start is called before the first frame update
    #region start
    void Start()
    {
        if (cursurHidden)
        {
            //locks cursor and toggles visible
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        euler = transform.eulerAngles;
    }

    #endregion

    #region update
    // Update is called once per frame
    void Update()
    {
        // rotate the camer based on mouse positon

        euler.y += Input.GetAxis("Mouse X") * speed.x * Time.deltaTime;
        //euler.x - yada yada because monitors start at zero on top left. Y axis goes negative going up. unity goes positive going up.
        euler.x -= Input.GetAxis("Mouse Y") * speed.y * Time.deltaTime;

        //clamp
       euler.x = Mathf.Clamp(euler.x, minPitch, maxPitch);
        //rotate player , camera
        transform.parent.localEulerAngles = new Vector3(0, euler.y, 0);
        transform.localEulerAngles = new Vector3(euler.x, 0, 0);
    }
    #endregion
}
