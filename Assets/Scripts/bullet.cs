using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
 
    // Update is called once per frame
    void Start()
    {
        Destroy(gameObject,3);
    }
  
}
