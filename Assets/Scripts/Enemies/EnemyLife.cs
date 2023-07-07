using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float enemyLife;
    public float enemyMaxLife = 100;

    private void Start()
    {
        enemyLife = enemyMaxLife;    
    }

    public void GetDamage(float damage)
    {
        enemyLife -= damage;

        if (enemyLife <= 0)
        {
            DestroyObject();
        }
        else
        {
            Debug.Log(gameObject.name + " recibió daño, le queda " + enemyLife + " de vida");
        }
    }

    private void DestroyObject()
    {
        Debug.Log(gameObject.name + " se murió");
        Destroy(gameObject);
    }
}
