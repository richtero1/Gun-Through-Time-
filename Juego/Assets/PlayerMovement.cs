using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    public Joystick j1;
    public Joystick j2;


    Vector2 movement;
    Vector2 mousePos;
    Vector2 direccion;


    public GameObject target;


    // Update is called once per frame
    void Update()
    {
        
        movement.x = j1.Horizontal;
        movement.y = j1.Vertical;

        direccion.x = j2.Horizontal;
        direccion.y = j2.Vertical;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookdir = direccion;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg -0f;
        rb.rotation = angle;
    }
    // Funcion para que el jugador sea matado por una bala
    /*private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(target);
        }
    }*/
}
