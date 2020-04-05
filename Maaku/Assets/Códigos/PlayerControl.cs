using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed = 4.0f, jumpSpeed = 10.0f;
    bool isJumping = false;
    /*Animator anim;
    
    void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Movement();

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
   
    */

    void Update()
    {
        if (Input.GetKey(KeyCode.D)) //Caminar a la derecha
        {
            if (GetComponent<SpriteRenderer>().flipX == true)
                GetComponent<SpriteRenderer>().flipX = false;

            GetComponent<Animator>().SetBool("caminar", true);
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A)) //Caminar a la izquierda
        {
            if (GetComponent<SpriteRenderer>().flipX == false)
                GetComponent<SpriteRenderer>().flipX = true;

            GetComponent<Animator>().SetBool("caminar", true);
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) ) { //Brincar
            transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
            isJumping = true;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) //Verificar cuando deja de caminar
            GetComponent<Animator>().SetBool("caminar", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Background")
            isJumping = false;
    }
}
