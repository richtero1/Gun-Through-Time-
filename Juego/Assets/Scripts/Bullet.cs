using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    public float Speed = 10f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        rb.velocity = transform.right * Speed;
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effect, 0.325f);
        Destroy(gameObject);
    }

    

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
