using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            
            if(player != null)
            {
                player.isKinematic = false;
                Vector2 difference = player.transform.position - transform.position;
                difference = difference.normalized * thrust;
                player.AddForce(difference, ForceMode2D.Impulse);
                player.isKinematic = true;
            }
        }
    }
}
