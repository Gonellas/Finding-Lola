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
            //target = GameObject.FindGameObjectWithTag("Player").transform;
            target = FindObjectOfType<PlayerMove>().transform;
        }
    }

    private void LateUpdate() //Se ejecuta a lo último de un frame. Se usa para control de la cámara.
    {
        if (target != null) transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

    }
}

