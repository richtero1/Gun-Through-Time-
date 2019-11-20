using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float Rotatespeed = 5f;
    public Transform target;
    float lookRadius;
    public Enemy e;

    public Rigidbody2D rb;
    public Transform pos1;
    public Transform pos2;

    Vector3 movpos;
    
    Renderer m_renderer;
    
    float distance;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        lookRadius = e.lookRadius;
        movpos = pos1.position;
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, lookRadius);
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance<lookRadius)
        {
            Rotar(target.position, Rotatespeed);
        }
        else if(distance > lookRadius && speed!=0)
        {

            transform.position = Vector2.MoveTowards(transform.position,
                                                  movpos,
                                                  speed * Time.deltaTime);
            Rotar(movpos, 1f);
            if (Vector2.Distance(transform.position, pos1.position) <.2)
            {
                
                movpos = pos2.position;
                
            }
            if (Vector2.Distance(transform.position, pos2.position) < .2)
            {

                movpos = pos1.position;
               
            }
        }




    }

    public void Rotar(Vector3 objetivo, float s)
    {
        direction = objetivo - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, transform.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                                rotation,
                                                s * Time.deltaTime);
    }





    //void OnDrawGizmos()
    //{
    //    Color color;
    //    color = Color.green;
    //    // local up
    //    DrawHelperAtCenter(this.transform.up, color, 2f);



    //    color = Color.blue;
    //    // local forward
    //    DrawHelperAtCenter(this.transform.forward, color, 2f);



    //    color = Color.red;
    //    // local right
    //    DrawHelperAtCenter(this.transform.right, color, 2f);


    //}

    //private void DrawHelperAtCenter(
    //    Vector3 direction, Color color, float scale)
    //{
    //    Gizmos.color = color;
    //    Vector3 destination = transform.position + direction * scale;
    //    Gizmos.DrawLine(transform.position, destination);
    //}



}
