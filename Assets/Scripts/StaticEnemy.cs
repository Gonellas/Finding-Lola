using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform enemyBulletSpawner;

    public float shootCooldown = 0f;
    public float cooldownTimer = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown <= 0)
        {
            Shoot();
        }

        if (shootCooldown > 0) shootCooldown -= 1 * Time.deltaTime;        
    }

    void Shoot()
    {
        shootCooldown = cooldownTimer;
        Instantiate(enemyBulletPrefab, enemyBulletSpawner.position, enemyBulletSpawner.rotation);
    }
}
