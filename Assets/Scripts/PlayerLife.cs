using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public float playerLife;
    public float playerMaxLife = 100;

    private void Start()
    {
        playerLife = playerMaxLife;
    }

    public void GetDamage(float damage)
    {
        playerLife -= damage;

        if (playerLife <= 0)
        {
            DestroyObject();
        }
        else
        {
            Debug.Log(gameObject.name + " recibi� da�o, le queda " + playerLife + " de vida");
        }
    }

    private void DestroyObject()
    {
        Debug.Log(gameObject.name + " se muri�");
        Destroy(gameObject);
    }

    public void GetHeal(float healingNumber)
    {
        playerLife += healingNumber;
        if (playerLife > playerMaxLife)
        {
            playerLife = playerMaxLife;
        }
        Debug.Log(gameObject.name + " recibi� vida, le queda " + playerLife + " de vida");
    }
}
