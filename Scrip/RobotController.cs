using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    //idle 0, run 1, slide 2, melee 3, shoot 4, runshoot 5, dead 6;
    // Start is called before the first frame update
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
            rb.velocity = new Vector2(5,0);
            sr.flipX = false;
            ChangeAni = 1;
        }
        //Correr Izquierda
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-5,0);
            sr.flipX = true;
            ChangeAni = 1;
        }
        //Slide Derecha
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)){
            ChangeAni = 2;
        }
        //Slide Izquierda
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)){
            ChangeAni = 2;
        }
        //Melee
        if(Input.GetKey(KeyCode.Q)){
            rb.velocity = new Vector2(0,0);
            ChangeAni = 3;
        }
        //Shoot
        if(Input.GetKey(KeyCode.W)){
            rb.velocity = new Vector2(0,0);
            ChangeAni = 4;
        }
        //RunShoot
        if((Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X))){
            ChangeAni = 5;
        }
        //Dead
        if(Input.GetKey(KeyCode.F)){
            rb.velocity = new Vector2(0,0);
            ChangeAni = 6;
        }

        ani.SetInteger("Estado", ChangeAni);
    }
}
