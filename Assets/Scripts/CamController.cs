using UnityEngine;

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

