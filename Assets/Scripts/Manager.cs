using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public Player player;
    public Enemies enemy;
    public bool cursorHidden = true;
    Text health;
    Text round;
    GameObject Mobile;
    // Start is called before the first frame update
    void Start()
    {
        if (cursorHidden)
        {
            //locks cursor and toggles visible
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        health = GameObject.Find("Health").GetComponent<Text>();
        round = GameObject.Find("Round").GetComponent<Text>();
        Mobile = GameObject.Find("MobileUI");
        if (Application.isMobilePlatform)
        {
            Mobile.SetActive(true);
        }
        else { Mobile.SetActive(false); }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        health.text = player.health.ToString();
        round.text = enemy.deathcounter.ToString();
        if (!Application.isMobilePlatform)
        {
            if (player.health <= 0)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        if (player.health <= 0)
        {
            player.enabled = false;
            enemy.enabled = false;
        }
        else
        {
            player.enabled = true;
            enemy.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
