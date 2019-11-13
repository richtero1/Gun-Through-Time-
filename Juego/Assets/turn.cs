using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.localRotation *= Quaternion.Euler(0, 0, 180);
    }
}
