using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform target; //busca al player
    public int speed;
    //public GameObject enemyAnimator;
    bool playerSpotted;
    public Animator enemyAnim;
    public bool isMoving;

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

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                // Mover hacia la derecha
                transform.position += Vector3.right * speed * Time.deltaTime;
                SetMovementAnimations(true, false, false, false);
            }
            else
            {
                // Mover hacia la izquierda
                transform.position += Vector3.left * speed * Time.deltaTime;
                SetMovementAnimations(false, true, false, false);
            }
        }
        else
        {
            if (direction.y > 0)
            {
                // Mover hacia arriba
                transform.position += Vector3.up * speed * Time.deltaTime;
                SetMovementAnimations(false, false, true, false);
            }
            else
            {
                // Mover hacia abajo
                transform.position += Vector3.down * speed * Time.deltaTime;
                SetMovementAnimations(false, false, false, true);
            }
        }

        // Si el enemigo no está en movimiento, restablecer las animaciones
        if (direction == Vector3.zero)
        {
            SetMovementAnimations(false, false, false, false);
        }
    
    }

    void SetMovementAnimations(bool movingRight, bool movingLeft, bool movingUp, bool movingDown)
    {
        enemyAnim.SetBool("isWalkingRight", movingRight);
        enemyAnim.SetBool("isWalkingLeft", movingLeft);
        enemyAnim.SetBool("isWalkingUp", movingUp);
        enemyAnim.SetBool("isWalkingDown", movingDown);
    }

        public void PlayerHasBeenSeen()
    {
        if (!playerSpotted) playerSpotted = true;
        else playerSpotted= false;
    }
}
