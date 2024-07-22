using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    public float bulletDamage = 25f;
    private Vector3 direction;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += speed * transform.right * Time.deltaTime;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<DestructibleObject>().GetDamage();
        }

        if (collision.gameObject.layer == 3)
        {
            collision.gameObject.GetComponent<EnemyLife>().GetDamage(bulletDamage);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Animator enemyDamaged = collision.gameObject.GetComponentInChildren<Animator>();

            if (enemyDamaged != null) enemyDamaged.SetBool("isDamaged", true);
            EnemyLife enemyLife = collision.gameObject.GetComponent<EnemyLife>();
            enemyLife.GetDamage(bulletDamage);
            Debug.Log("da�o hecho" + bulletDamage++);
            //collision.gameObject.GetComponent<EnemyLife>().GetDamage(bulletDamage);
        }

        Destroy(gameObject);
    }
}
