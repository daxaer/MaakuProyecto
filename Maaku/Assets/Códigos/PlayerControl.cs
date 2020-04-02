using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Animator anim;
    public float moveSpeed = 4.0f, jumpSpeed = 10.0f;
    bool triggered = false;

    private void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && triggered)
            SceneManager.LoadScene("Patio");
    }
}
