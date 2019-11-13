using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    public static bool MoveRight;
    public float Rotatespeed = 5f;
    public Transform target;
    float lookRadius;
    private Renderer m_renderer;
    public Enemy e;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        lookRadius = e.lookRadius;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (MoveRight && distance > lookRadius)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
        else if(!MoveRight && distance > lookRadius)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-0.5f, 0.5f);
        }
        

        else if (distance <= lookRadius && m_renderer.isVisible)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Rotatespeed * Time.deltaTime);
        }
    }
}
