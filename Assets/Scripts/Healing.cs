using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public float healingAmount = 50f;
    private bool isPlayerInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKey(KeyCode.E))
        {
            PlayerLife _playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();

            if (_playerLife.playerLife < _playerLife.playerMaxLife)
            {
                _playerLife.GetHeal(healingAmount);
                Destroy(gameObject);
            }
        }
    }
}