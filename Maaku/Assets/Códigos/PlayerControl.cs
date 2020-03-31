using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Animator anim;
    private float moveSpeed = 4f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        
    }

}
