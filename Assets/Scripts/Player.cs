using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    public Rigidbody2D rdb2D;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        rdb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * (Time.deltaTime * Speed);

        if (Input.GetAxis("Horizontal") > 0f)  //player andando para Direira
        {
            _animator.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)  //player andando para Esquerda
        {
            _animator.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0f) 
        {
            _animator.SetBool("Andando", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rdb2D.AddForce(new Vector2(0f, JumpForce * 1.19f), ForceMode2D.Impulse);
                doubleJump = true;
                _animator.SetBool("Pulando",true);
            }
            else if (doubleJump)
            {
                rdb2D.AddForce(new Vector2(0f, JumpForce / 2.5f), ForceMode2D.Impulse);
                doubleJump = false;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 6)
        {
            isJumping = false;
            _animator.SetBool("Pulando",false);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }
}