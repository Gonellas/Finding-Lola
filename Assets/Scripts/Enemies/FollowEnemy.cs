using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform target;
    public int speed;
    bool playerSpotted;
    public Animator enemyAnim;
    public bool isMoving;
    public int damage = 15;

    void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerMove>().transform;
        }
    }
    
    void Update()
    {
        if (target == null) return;

        if (playerSpotted) followPlayerRotationSpottedPoint();
        else
        {
            SetMovementAnimations(false, false, false, false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<PlayerLife>().GetDamage(damage);
        }
    }
    void followPlayerRotationSpottedPoint() 
    {

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
