using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ControlerRobot : MonoBehaviour
{
    public float runSpeeed = 9;
    Rigidbody2D rb2D;

    public SpriteRenderer spriteRenderer;

    Animator animacion;
    public int Idle;
    public int Disparar;
    public int Deslizarse;
    public int CorrerDisparar;
    public int Morir;
    public int Peleas;
    public int Correr;

    bool bandera = false;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (bandera == false)
        {
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                ChangeAnimation(Correr);
                rb2D.velocity = new Vector2(runSpeeed, rb2D.velocity.y);
                spriteRenderer.flipX = false;



            }
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                rb2D.velocity = new Vector2(-runSpeeed, rb2D.velocity.y);
                spriteRenderer.flipX = true;
                ChangeAnimation(Correr);
            }
            else
            {
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
                ChangeAnimation(Idle);
            }

            //Animación
            if (Input.GetKey("z"))
            {
                ChangeAnimation(Peleas);
            }

            if (Input.GetKey("x"))
            {
                ChangeAnimation(Deslizarse);
            }

            if (Input.GetKey("c"))
            {
                ChangeAnimation(Disparar);
            }

            if (Input.GetKey("v"))
            {
                ChangeAnimation(CorrerDisparar);
            }

            if (Input.GetKey("b"))
            {
                ChangeAnimation(Morir);
                bandera = true;
                Destroy(gameObject,1);
            }
        }
    }
    private void ChangeAnimation(int animat)
    {
        animacion.SetInteger("Estado",animat);
    }

   // private void OnCollisionEnter2D(Collision2D other)
    //{
      //  if (other.gameObject.name == "Triangle")
       // {
        //    ChangeAnimation(Deslizarse);
       // }
   // }


}
