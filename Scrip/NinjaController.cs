using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    // Start is called before the first frame update
    //Idle = 0, Attack = 1, Run = 2, Slide = 3, Throw = 4, Dead = 5
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator ani;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int ChangeAni = 0;
        rb.velocity = new Vector2(0, 0);

        //Correr Derecha
        if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(10,0);
            sr.flipX = false;
            ChangeAni = 2;
        }
        //Correr Izquierda
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-10,0);
            sr.flipX = true;
            ChangeAni = 2;
        }
        //Slide Derecha
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)){
            ChangeAni = 3;
        }
        //Slide Izquierda
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)){
            ChangeAni = 3;
        }
        //Atacar
        if(Input.GetKey(KeyCode.Q)){
            rb.velocity = new Vector2(0,0);
            ChangeAni = 1;
        }
        //Dead
        if(Input.GetKey(KeyCode.F)){
            rb.velocity = new Vector2(0,0);
            ChangeAni = 5;
        }
        //Throw
        if(Input.GetKey(KeyCode.W)){
            rb.velocity = new Vector2(0,0);
            ChangeAni = 4;
        }
        ani.SetInteger("Estado", ChangeAni);
    }
}
