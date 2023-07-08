using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform enemyBulletSpawner;

    public float shootCooldown = 0f;
    public float cooldownTimer = 2f;

    public Transform target;
    public float minDistanceToShoot; 
    bool playerSpotted;

    public Animator enemyAnim;
    public AudioSource audioSource;

    void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerMove>().transform;
        }
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector2.Distance(target.position, transform.position); 

        if (distance < minDistanceToShoot) playerSpotted = true;
        else playerSpotted = false;

        if (shootCooldown <= 0 && playerSpotted == true)
        {
            Shoot();
        }

        if (playerSpotted) followPlayerSpottedPoint();

        if (shootCooldown > 0) shootCooldown -= 1 * Time.deltaTime;
    }     

     private void Shoot()
    {
        shootCooldown = cooldownTimer;
        GameObject bullet = Instantiate(enemyBulletPrefab, enemyBulletSpawner.position, Quaternion.identity);
        audioSource.Play();

        Vector3 direction = target.position - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void followPlayerSpottedPoint()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        float absoluteX = Mathf.Abs(direction.x);
        float absoluteY = Mathf.Abs(direction.y);

        enemyAnim.SetBool("isShootingUp", false);
        enemyAnim.SetBool("isShootingDown", false);
        enemyAnim.SetBool("isShootingLeft", false);
        enemyAnim.SetBool("isShootingRight", false);
      
        if (absoluteX > absoluteY)
        {
            if (direction.x > 0)
            {
                enemyAnim.SetBool("isShootingRight", true);
            }
            else
            {
                enemyAnim.SetBool("isShootingLeft", true);
            }
        }
        else
        {
            if (direction.y > 0)
            {
                enemyAnim.SetBool("isShootingUp", true);
            }
            else
            {
                enemyAnim.SetBool("isShootingDown", true);
            }
        }
    }

}