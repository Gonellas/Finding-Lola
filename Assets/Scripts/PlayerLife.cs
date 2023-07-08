using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public float playerLife;
    public float playerMaxLife = 100;
    public LifeCanvas lifeCanvas;
    GameManager gameManager;
    public AudioSource healSound;
    public AudioSource damageSound;

    private void Start()
    {
        playerLife = playerMaxLife;
        lifeCanvas = FindObjectOfType<LifeCanvas>();
        lifeCanvas.UpdateLife(playerLife, playerMaxLife);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GetDamage(float damage)
    {
        playerLife -= damage;
        damageSound.Play();

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
}
