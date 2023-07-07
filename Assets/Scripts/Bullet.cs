using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Velocidad Bullet
    public float speed = 10f;
    //Vida Bullet en el tiempo
    public float lifeTime = 3f;
    //Da�o de la bala
    public float bulletDamage = 25f;

    public Animator enemyDamaged;


    private void Start()
    {
        //Destruye el objeto bullet en 3seg
        Destroy(gameObject, lifeTime);
        enemyDamaged = GameObject.FindWithTag("Enemy").GetComponent<Animator>();

    }
    private void Update()
    {
        //Direcci�n y movimiento bullet
        transform.position += speed * transform.right * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            //Del objeto con el que colision�, quiero su objeto en el mundo, su script nombre, y una vez
            //que lo obtuve traeme x funci�n
            collision.gameObject.GetComponent<DestructibleObject>().GetDamage();
        }

        //El da�o de la bala influye en el enemy
        if (collision.gameObject.layer == 3)
        {
            collision.gameObject.GetComponent<EnemyLife>().GetDamage(bulletDamage);
        }

        //Si entra en colisi�n se destruye
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            enemyDamaged.SetBool("isDamaged", true);
            collision.gameObject.GetComponent<EnemyLife>().GetDamage(bulletDamage);
        }

        Destroy(gameObject);

    }


}
