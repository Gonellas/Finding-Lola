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

        if (enemyAnim == null)
        {
            Debug.LogWarning("Animator component not found in the child object.");
        }

        gameManager = FindObjectOfType<GameManager>();
    }

    public void GetDamage(float damage)
    {
        enemyLife -= damage;

        if (enemyAnim != null)
        {
            enemyAnim.SetTrigger("isDamaged");
        }

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
