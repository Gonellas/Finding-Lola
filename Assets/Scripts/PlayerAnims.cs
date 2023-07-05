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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnim.SetTrigger("isShooting");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAnim.SetBool("isRunning", true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("isRunning", false);
        }
    }
}
