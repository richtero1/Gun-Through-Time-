using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    public float Speed = 2f;

    Rigidbody2D rb;

    private Transform target;
    Vector2 moveDirection;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        moveDirection = (target.position - transform.position).normalized * Speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effect, 0.325f);
        Destroy(gameObject);
    }

}
