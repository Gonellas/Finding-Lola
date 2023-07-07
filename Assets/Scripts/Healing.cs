using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public float healingAmount = 50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == 8)
        //{
        //    PlayerLife _playerLife = collision.gameObject.GetComponent<PlayerLife>();

        //    if(_playerLife.playerLife < _playerLife.playerMaxLife) 
        //    {
        //        _playerLife.GetHeal(healingAmount);
        //        Destroy(gameObject);
        //    }
        //}

        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            PlayerLife _playerLife = collision.gameObject.GetComponent<PlayerLife>();

            if (_playerLife.playerLife < _playerLife.playerMaxLife)
            {
                _playerLife.GetHeal(healingAmount);
                Destroy(gameObject);
            }
        }
    }
}

