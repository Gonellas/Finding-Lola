using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour
{
    public float playerLife;
    public float playerMaxLife = 100;
    public LifeCanvas lifeCanvas;
    GameManager gameManager;
    public AudioSource healSound;
    public AudioSource damageSound;
    public Animator playerAnim;

    public bool isBlocking = false;
    public float blockDuration = 1.0f; // Duration of the block state
    public float blockCooldown = 3.0f; // Cooldown time for blocking
    private float blockCooldownTimer = 0f;

    private void Start()
    {
        playerLife = playerMaxLife;
        lifeCanvas = FindObjectOfType<LifeCanvas>();
        lifeCanvas.UpdateLife(playerLife, playerMaxLife);
        gameManager = FindObjectOfType<GameManager>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && blockCooldownTimer <= 0f)
        {
            StartCoroutine(Block());
        }

        if (blockCooldownTimer > 0f)
        {
            blockCooldownTimer -= Time.deltaTime;
        }
    }

    public void GetDamage(float damage)
    {
        if (!isBlocking)
        {
            playerLife -= damage;
            damageSound.Play();
            playerAnim.SetTrigger("isDamaged");

            if (playerLife <= 0)
            {
                DestroyObject();
            }
            else
            {
                lifeCanvas.UpdateLife(playerLife, playerMaxLife);
                Debug.Log(gameObject.name + " recibió daño, le queda " + playerLife + " de vida");
            }
        }
        else
        {
            Debug.Log(gameObject.name + " blocked the damage.");
        }
    }

    private void DestroyObject()
    {
        lifeCanvas.UpdateLife(playerLife, playerMaxLife);
        Debug.Log(gameObject.name + " se murió");

        gameManager.DefeatedMenu();
        Destroy(gameObject);
    }

    public void GetHeal(float healingNumber)
    {
        playerLife += healingNumber;
        healSound.Play();
        if (playerLife > playerMaxLife)
        {
            playerLife = playerMaxLife;
        }
        lifeCanvas.UpdateLife(playerLife, playerMaxLife);
        Debug.Log(gameObject.name + " recibió vida, le queda " + playerLife + " de vida");
    }

    private IEnumerator Block()
    {
        isBlocking = true;
        playerAnim.SetBool("isBlocking", true);
        yield return new WaitForSeconds(blockDuration);
        isBlocking = false;
        playerAnim.SetBool("isBlocking", false);
        blockCooldownTimer = blockCooldown;
    }
}