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
        if(shootCooldown <= 0 && Input.GetMouseButton(0))
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

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        Vector3 direction = mousePosition - bulletSpawner.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bulletSpawner.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);

        bullet.GetComponent<Bullet>().SetDirection(direction);
    }
}
