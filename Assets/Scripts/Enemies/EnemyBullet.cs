using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //Velocidad Bullet
    public float speed = 10f;
    //Vida Bullet en el tiempo
    public float lifeTime = 3f;
    //Daño de la bala
    public float bulletDamage = 25f;

    public Animator playerDamaged;

    private void Start()
    {
        //Destruye el objeto bullet en 3seg
        Destroy(gameObject, lifeTime);
        playerDamaged = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }
    private void Update()
    {
        //Dirección y movimiento bullet
        transform.position += speed * transform.right * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            //Del objeto con el que colisioné, quiero su objeto en el mundo, su script nombre, y una vez
            //que lo obtuve traeme x función
            collision.gameObject.GetComponent<DestructibleObject>().GetDamage();
        }

        //El daño de la bala influye en el enemy
        if (collision.gameObject.layer == 8)
        {
            playerDamaged.SetTrigger("isDamaged");
            collision.gameObject.GetComponent<PlayerLife>().GetDamage(bulletDamage);
        }

        //Si entra en colisión se destruye
        Destroy(gameObject);
    }

}
