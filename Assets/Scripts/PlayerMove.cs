using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D RB2D;
    public float dashForce, speed;    
    public KeyCode dashKey;
    float aXH, aXV;

    Vector2 direction;

    //public float maxPlayerLife = 100;
    //public float playerLife;

    //private bool isDamaging;

    //public float damageCooldown = 0.5f;
    //public float timerCooldown = 0;

    private void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        //playerLife = maxPlayerLife;
    }
    private void Update()
    {
         aXH = Input.GetAxisRaw("Horizontal");
         aXV = Input.GetAxisRaw("Vertical");

        //Movement
        //transform.position += (Vector3.right * aXH + Vector3.up * aXV) * speed * Time.deltaTime;

        direction = new Vector2(aXH, aXV).normalized;           

        //Dash
        if (Input.GetKeyDown(dashKey) && direction != Vector2.zero)
        {           
            RB2D.AddForce(direction * dashForce, ForceMode2D.Impulse);
        }

        ////Si timerCooldown es menor a damageCooldown, se suma un timerCooldown
        //if (timerCooldown < damageCooldown) timerCooldown += Time.deltaTime;

        //if (isDamaging && timerCooldown >= damageCooldown)
        //{
        //    playerLife -= 10;
        //    timerCooldown = 0;

        //    if(playerLife == 0)
        //    {
        //        Debug.Log("Moriste");

        //        Destroy(gameObject);
        //    }
        //    else
        //    {
        //        Debug.Log("Todavía seguís vivo. Te queda: " + playerLife);
        //    }
        //}
    }

    private void FixedUpdate()
    {
        RB2D.MovePosition((Vector3)RB2D.position + (Vector3.right * aXH + Vector3.up * aXV) * speed * Time.fixedDeltaTime);
        //RB2D.AddForce(direction * speed, ForceMode2D.Force);

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
      
    //    //Si choco con enemie me hace daño
    //    if(collision.gameObject.tag == "CustomTag" || collision.gameObject.layer == 6) isDamaging = true;

    //    //Si choco con objeto destruíble se destruye
    //    if (collision.gameObject.layer == 7) Destroy(collision.gameObject);

    //    //Pasame el nombre del objeto donde está el script + coment + nombre del objeto donde estoy collisionando
    //    Debug.Log(this.gameObject.name + "entré en colisión" + collision.gameObject.name);
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    isDamaging = false;

    //    Debug.Log(this.gameObject.name + "salí de colisión" + collision.gameObject.name);
    //}
}
