using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public JoyStick movementJoystick;
    public JoyStick rotationJoystick;
    public float runSpeed = 3.5f, horizontalRotateSpeed = 100f, verticalRotateSpeed = 50f;
    public LayerMask doorLayerMask;
    public Camera cam;
    public int randomRoom;
    public int randomDoor;
    public GameObject[] rooms;
    public Transform[] doorsInRoom0;
    public Transform[] doorsInRoom1;
    public Transform[] doorsInRoom2;
    public Transform[] doorsInRoom3;

    public Transform[] enemiesInRoom1;
    public Transform[] enemiesInRoom2;
    public Transform[] enemiesInRoom3;
    public GameObject player;
    public GameObject enemy;
    public GameObject clone;
    Vector3 rot;

    void Update()
    {
        rot += new Vector3(-rotationJoystick.Vertical * verticalRotateSpeed, rotationJoystick.Horizontal * horizontalRotateSpeed, 0f) * Time.deltaTime;
        rot.x = Mathf.Clamp(rot.x, -50f, 70f);
        transform.position += transform.TransformDirection(new Vector3(movementJoystick.Horizontal, 0f, movementJoystick.Vertical) * runSpeed * Time.deltaTime);
        //transform.rotation *= Quaternion.Euler(0f , movementJoystick.Horizontal * rotateSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.Euler(0f, rot.y, 0f);
        cam.transform.localRotation = Quaternion.Euler(rot.x, 0f, 0f);
    }

    public void InteractButton()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1f, doorLayerMask))
        {
            randomRoom = Random.Range(0, rooms.Length);
            if (randomRoom == 0)
            {
                randomDoor = Random.Range(0, doorsInRoom0.Length);
                player.transform.position = doorsInRoom0[randomDoor].position;
                rot = doorsInRoom0[randomDoor].rotation.eulerAngles;
            }
            if (randomRoom == 1)
            {
                randomDoor = Random.Range(0, doorsInRoom1.Length);
                player.transform.position = doorsInRoom1[randomDoor].position;
                rot = doorsInRoom1[randomDoor].rotation.eulerAngles;
                for (int i = 0; i < enemiesInRoom1.Length; i++)
                {
                    clone = Instantiate(enemy, enemiesInRoom1[i]);
                    
                }
            }
            if (randomRoom == 2)
            {
                randomDoor = Random.Range(0, doorsInRoom2.Length);
                player.transform.position = doorsInRoom2[randomDoor].position;
                rot = doorsInRoom2[randomDoor].rotation.eulerAngles;
                for (int i = 0; i < enemiesInRoom2.Length; i++)
                {
                    clone = Instantiate(enemy, enemiesInRoom2[i]);
                }
            }
            if (randomRoom == 3)
            {
                randomDoor = Random.Range(0, doorsInRoom3.Length);
                player.transform.position = doorsInRoom3[randomDoor].position;
                rot = doorsInRoom3[randomDoor].rotation.eulerAngles;
                for (int i = 0; i < enemiesInRoom3.Length; i++)
                {
                    clone = Instantiate(enemy, enemiesInRoom3[i]);
                }
            }
        }
        else
        {
            Debug.Log("Shoot");
        }
    }
}
