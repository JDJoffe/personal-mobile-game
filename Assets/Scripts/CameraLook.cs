using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    #region var
    [Header("Var")]
    public bool cursorHidden = true;
    public float minPitch = -80f, maxPitch = 80f;
    Vector3 euler;
    #endregion
    // Start is called before the first frame update
    #region start
    void Start()
    {
        if (cursorHidden)
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
        transform.Rotate(euler.y += Input.GetAxis("Mouse X"), euler.x -= Input.GetAxis("Mouse Y"), 0);
        

        // smoother cam
        euler.x = Mathf.Clamp(euler.x, minPitch, maxPitch);
        // rotate player , camera
        transform.parent.localEulerAngles = new Vector3(0, euler.y, 0);
        transform.localEulerAngles = new Vector3(euler.x, 0, 0);
        
    }
    #endregion
}
