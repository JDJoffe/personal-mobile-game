using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    #region var
    [Header("Var")]
   
    public float minPitch = -80f, maxPitch = 80f;
    public Vector3 euler;
    public Camera cam;
    public JoyStick rotStick;
    public float horizontalRotateSpeed = 100f, verticalRotateSpeed = 50f;
   public bool isPC;
    #endregion
    // Start is called before the first frame update
    #region start
    void Start()
    {
       if(!Application.isMobilePlatform)
       {
            isPC = true;
       }
        euler = transform.eulerAngles;
    }

    #endregion

    #region update
    // Update is called once per frame
    void Update()
    {
        if(isPC)
        {
        // rotate the camer based on mouse positon
        transform.Rotate(euler.y += Input.GetAxis("Mouse X"), euler.x -= Input.GetAxis("Mouse Y"), 0);
        

        // smoother cam
        euler.x = Mathf.Clamp(euler.x, minPitch, maxPitch);
        // rotate player , camera
        transform.parent.localEulerAngles = new Vector3(0, euler.y, 0);
        transform.localEulerAngles = new Vector3(euler.x, 0, 0);
        }
        else
        {
        euler += new Vector3(-rotStick.Vertical * verticalRotateSpeed, rotStick.Horizontal * horizontalRotateSpeed, 0f) * Time.deltaTime;
       // euler.x = Mathf.Clamp(euler.x, -minPitch, maxPitch);
    transform.parent.localEulerAngles = new Vector3(0, euler.y, 0);
    //transform.localEulerAngles  = new Vector3(euler.x, 0, 0);
        transform.localEulerAngles = new Vector3(euler.x, 0, 0);
        }
    }
    #endregion
}
