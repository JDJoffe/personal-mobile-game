using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
        private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(target.forward);
    }
}
