using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;

    private void Awake()
    {
        if(target == null)
        {
            //target = GameObject.FindGameObjectWithTag("Player").transform;
            target = FindObjectOfType<PlayerMove>().transform;
        }
    }

    private void LateUpdate()
    {
        //if(target != null) 
    }
}
