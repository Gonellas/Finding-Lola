using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float enemyLife;
    public float enemyMaxLife = 100;

    Animator enemyAnim;

    private GameManager gameManager;

    private void Start()
    {
        enemyLife = enemyMaxLife;    
        enemyAnim = GetComponentInChildren<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GetDamage(float damage)
    {
        enemyLife -= damage;
        enemyAnim.SetTrigger("isDamaged");

        if (enemyLife <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameManager != null)
        {
            gameManager.EnemyDefeated(this.gameObject);
        }
        Destroy(gameObject);
    }
}
