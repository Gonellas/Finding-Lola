using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //Pasar el prefab de bullet, no el objeto que está en hierarchy
    public GameObject bulletPrefab;

    //Llamo al transform del objeto directamente
    public Transform bulletSpawner;

    public float shootCooldown = 0;
    public float cooldownTimer = 0.5f;

    private void Update()
    {
        if(shootCooldown <= 0 && Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }

        if(shootCooldown > 0)
        {
            shootCooldown -= 1 * Time.deltaTime;
        }
    }

    private void Shoot()
    {
        shootCooldown = cooldownTimer;
        Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
    }
}
