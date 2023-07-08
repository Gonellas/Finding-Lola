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
    private Transform target;
    public Animator playerDamaged;
    public GameManager gameManager;

    private void Start()
    {
        //Destruye el objeto bullet en 3seg
        Destroy(gameObject, lifeTime);
        playerDamaged = GameObject.FindWithTag("Player").GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        //Dirección y movimiento bullet
        transform.position += speed * transform.right * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            playerDamaged.SetTrigger("isDamaged");
            
            collision.gameObject.GetComponent<PlayerLife>().GetDamage(bulletDamage);
        }

        //gameManager.DefeatedMenu().SetActive(true);
        Destroy(gameObject);
    }
}
