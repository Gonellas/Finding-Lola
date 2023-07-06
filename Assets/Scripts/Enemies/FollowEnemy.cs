using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform target; //busca al player
    public int speed;
    bool playerSpotted;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerMove>().transform;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

       if (playerSpotted) followPlayerRotationSpottedPoint();
    }

    void followPlayerRotationSpottedPoint() //El enemigo rota al descubrir al personaje
    {
        Vector3 direction = target.position - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction); //(Vector2.right o left según como está la imágen)
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        direction = direction.normalized;
        transform.position += direction * speed * Time.deltaTime; 
    }

    public void PLayerHasBeenSeen()
    {
        if (!playerSpotted) playerSpotted = true;
        else playerSpotted= false;
    }
}
