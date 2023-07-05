using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform enemyBulletSpawner;

    public float shootCooldown = 0f;
    public float cooldownTimer = 2f;

    public Transform target; //busca al player
    public float minDistanceToShoot; //distancia a la cual ve al jugador y dispara
    bool playerSpotted;//cuando el personaje sea descubierto, el enemigo dispara

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        float distance = Vector2.Distance(target.position, transform.position); //distancia que hay entre el target y la posición.

        if(distance < minDistanceToShoot) playerSpotted= true;
        else playerSpotted= false;  

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
