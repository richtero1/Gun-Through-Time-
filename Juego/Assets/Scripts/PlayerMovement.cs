using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
     
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Camera cam;

    public Joystick j1;
    public Joystick j2;

    Vector2 movement;
    Vector2 mousePos;
    Vector2 direccion;
    float timer; 
    public Transform spawnPoint;

    public GameObject target;

    public bool controles;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            sprite.color = Color.white;
            timer = 0;
        }
            
        //controles tactiles o Manuales para casos de prueba
        if (controles == true)
        {
            movement.x = j1.Horizontal;
            movement.y = j1.Vertical;
            if (j2.Horizontal != 0f || j2.Vertical != 0f)
            {
                direccion.x = j2.Horizontal;
                direccion.y = j2.Vertical;
            }
        } 
        else 
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            direccion = mousePos - rb.position;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookdir = direccion;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg -0f;
        rb.rotation = angle;
    }

    // Controlador de vidas
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            StartCoroutine("GetInvulnerable");
            GameControl.health -= 1;
            Handheld.Vibrate();
            sprite.color = Color.red;
        }

        if (col.gameObject.tag.Equals("Heart"))
        {
            GameControl.health += 1;
            Destroy(col.gameObject);
            ScoreScript.scoreValue += 50;
        }
    }
    
    protected IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        Debug.Log("esperando dos seg");
        yield return new WaitForSeconds(2f);
        Debug.Log("pasaron dos seg");
        Physics2D.IgnoreLayerCollision(8, 9, false);
       
    }
}
