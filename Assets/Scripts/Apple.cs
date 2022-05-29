using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private CircleCollider2D _circleCollider2D;

    public GameObject collected;

    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _spriteRenderer.enabled = false;
            _circleCollider2D.enabled = false;
            collected.SetActive(true);
            GameController.instance.totalScore += Score;
           GameController.instance.UpdateScoreText();
           Destroy(gameObject,0.2f);
        }
    }
}
