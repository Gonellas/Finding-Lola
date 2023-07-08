using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CamController : MonoBehaviour
{
    public Transform target;

    private void Awake()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerMove>().transform;
        }
    }

    private void LateUpdate() 
    {
        if (target != null) transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}

