using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float enemyLife;
    public float enemyMaxLife = 100;

    Animator enemyAnim;

    private void Start()
    {
        enemyLife = enemyMaxLife;    
        enemyAnim = GetComponentInChildren<Animator>();
    }

    public void GetDamage(float damage)
    {
        enemyLife -= damage;
        enemyAnim.SetTrigger("isDamaged");

        if (enemyLife <= 0)
        {
            DestroyObject();
        }
        else
        {
            Debug.Log(gameObject.name + " recibi� da�o, le queda " + enemyLife + " de vida");
        }
    }

    private void DestroyObject()
    {
        Debug.Log(gameObject.name + " se muri�");
        Destroy(gameObject);
    }
}
