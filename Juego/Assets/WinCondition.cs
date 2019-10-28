using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    public GameObject win, restart2;

    // Start is called before the first frame update
    void Start()
    {
        win.gameObject.SetActive(false);
        restart2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            win.gameObject.SetActive(true);
            restart2.gameObject.SetActive(true);
        }
    }
}
