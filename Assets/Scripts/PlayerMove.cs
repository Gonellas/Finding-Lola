using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D RB2D;
    public float dashForce, speed, playerRotateSpeed;    
    public KeyCode dashKey;
    float aXH, aXV;
    Vector2 direction;

    private void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();;
    }
    private void Update()
    {
        aXH = Input.GetAxisRaw("Horizontal");
        aXV = Input.GetAxisRaw("Vertical");

        direction = new Vector2(aXH, aXV).normalized;

        //Dash
        if (Input.GetKeyDown(dashKey) && direction != Vector2.zero)
        {
            RB2D.AddForce(direction * dashForce, ForceMode2D.Impulse);
        }

        Debug.Log("Dash" + Input.GetKeyDown(dashKey));
    }

    private void FixedUpdate()
    {
        //Movement
        transform.position += (Vector3.right * aXH + Vector3.up * aXV) * speed * Time.deltaTime;
    }
}
