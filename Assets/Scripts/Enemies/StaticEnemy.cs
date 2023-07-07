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

    public Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerMove>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        float distance = Vector2.Distance(target.position, transform.position); //distancia que hay entre el target y la posición.

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

        Vector3 direction = target.position - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void followPlayerSpottedPoint()
    {

            /*Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/

            //Vector3 direction = target.position - transform.position;   
            //float angle = Vector2.SignedAngle(Vector2.right, direction); //(Vector2.right o left según como está la imágen)
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //if(target != null)
            //{
            //    Vector3 playerPosition = target.transform.position;
            //    Vector3 enemyPosition = transform.position;

            //    enemyAnim.SetBool("isShootingUp", playerPosition.y > enemyPosition.y);
            //    enemyAnim.SetBool("isShootingLeft", playerPosition.x < enemyPosition.x);
            //    enemyAnim.SetBool("isShootingRight", playerPosition.x > enemyPosition.x);
            //    enemyAnim.SetBool("isShootingDown", playerPosition.y < enemyPosition.y);

            //    //enemyAnim.SetTrigger("isDamaged");
            //}

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