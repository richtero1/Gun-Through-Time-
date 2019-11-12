using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Patrol.MoveRight)
            {
                Patrol.MoveRight = false;
            }
            else
            {
                Patrol.MoveRight = true;
            }
        }
    }
}
