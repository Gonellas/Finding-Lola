using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float speedBoost = 15f;
    public Rigidbody2D RB2D;
    public Animator playerAnim;
    public float dashForce, speed, playerRotateSpeed;
    private float aXH, aXV;
    public KeyCode dashKey;
    private Vector2 direction;
    private Vector2 _lastMovement = Vector2.zero;

    private float defaultSpeed;
    private bool isSpeedBoosted = false;

    public AudioSource walkingSound;

    private void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        defaultSpeed = speed; // Store the default speed
    }

    private void Update()
    {
        aXH = Input.GetAxisRaw("Horizontal");
        aXV = Input.GetAxisRaw("Vertical");

        direction = new Vector2(aXH, aXV).normalized;

        // Dash
        if (Input.GetKeyDown(dashKey) && direction != Vector2.zero)
        {
            RB2D.AddForce(direction * dashForce, ForceMode2D.Impulse);
        }

        Debug.Log("Dash" + Input.GetKeyDown(dashKey));

        UpdateRunningAnims(direction);
        UpdateShootingAnims();
        UpdateWalkingSound();
    }

    private void FixedUpdate()
    {
        // Movement
        transform.position += (Vector3.right * aXH + Vector3.up * aXV) * speed * Time.fixedDeltaTime;
    }

    private void UpdateRunningAnims(Vector2 movement)
    {
        if (movement.magnitude > 0)
        {
            playerAnim.SetBool("isRunning", true);
            playerAnim.SetFloat("aXH", movement.x);
            playerAnim.SetFloat("aXV", movement.y);
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
            playerAnim.SetFloat("aXH", _lastMovement.x);
            playerAnim.SetFloat("aXV", _lastMovement.y);
        }

        if (movement.magnitude > 0)
        {
            _lastMovement = movement;
        }
    }

    private void UpdateShootingAnims()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            playerAnim.SetBool("isAttacking", true);
            playerAnim.SetFloat("HAx", _lastMovement.x);
            playerAnim.SetFloat("VAx", _lastMovement.y);
            playerAnim.SetTrigger("isShooting");
        }
        else
        {
            playerAnim.SetBool("isAttacking", false);
            Debug.Log("se termino anim ataque");
        }
    }

    private void UpdateWalkingSound()
    {
        if (direction.magnitude > 0 && !walkingSound.isPlaying)
        {
            walkingSound.Play();
        }
        else if (direction.magnitude == 0 && walkingSound.isPlaying)
        {
            walkingSound.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            Debug.Log("Colision");
            StartCoroutine(SpeedBoostCoroutine());
            Destroy(collision.gameObject); 
        }
    }

    private IEnumerator SpeedBoostCoroutine()
    {
        if (!isSpeedBoosted)
        {
            isSpeedBoosted = true;
            speed = speedBoost; 

            yield return new WaitForSeconds(10f); 

            speed = defaultSpeed; 
            isSpeedBoosted = false;
        }
    }
}
