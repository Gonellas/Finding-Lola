using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnims : MonoBehaviour
{
    public Animator playerAnim;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            playerAnim.SetTrigger("isShooting");
        }

        //Running Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAnim.SetBool("isRunning", true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("isRunning", false);
        }

        //Running Up
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetBool("isRunningUp", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetBool("isRunningUp", false);
        }

        //Running Down
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetBool("isRunningDown", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetBool("isRunningDown", false);
        }
    }
}
