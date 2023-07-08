using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnims : MonoBehaviour
{
    public Animator playerAnim;
    public AudioSource audioSource;

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
            audioSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("isRunning", false);
            audioSource.Stop();


        }

        //Running Up
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetBool("isRunningUp", true);
            audioSource.Play();

        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetBool("isRunningUp", false);
            audioSource.Stop();

        }

        //Running Down
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetBool("isRunningDown", true);
            audioSource.Play();

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetBool("isRunningDown", false);
            audioSource.Stop();

        }

        //Running Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAnim.SetBool("isRunningLeft", true);
            audioSource.Play();

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.SetBool("isRunningLeft", false);
            audioSource.Stop();

        }


    }
}
