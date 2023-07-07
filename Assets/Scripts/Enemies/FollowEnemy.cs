using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform target; //busca al player
    public int speed;
    bool playerSpotted;
    public Animator enemyAnim;


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
        //Vector3 direction = target.position - transform.position;
        //float angle = Vector2.SignedAngle(Vector2.right, direction); //(Vector2.right o left según como está la imágen)
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //direction = direction.normalized;
        //transform.position += direction * speed * Time.deltaTime; 

        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime; 


        float absoluteX = Mathf.Abs(direction.x);
        float absoluteY = Mathf.Abs(direction.y);

        enemyAnim.SetBool("isWalkingUp", false);
        enemyAnim.SetBool("isWalkingDown", false);
        enemyAnim.SetBool("isWalkinggLeft", false);
        enemyAnim.SetBool("isWalkingRight", false);

        if (absoluteX > absoluteY)
        {
            if (direction.x > 0)
            {
                enemyAnim.SetBool("isWalkingRight", true);
            }
            else
            {
                enemyAnim.SetBool("isWalkingLeft", true);
            }
        }
        else
        {
            if (direction.y > 0)
            {
                enemyAnim.SetBool("isWalkingUp", true);
            }
            else
            {
                enemyAnim.SetBool("isWalkingDown", true);
            }
        }
    }


    public void PLayerHasBeenSeen()
    {
        if (!playerSpotted) playerSpotted = true;
        else playerSpotted= false;
    }
}
