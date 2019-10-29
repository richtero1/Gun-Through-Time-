using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{

    public GameObject win, restart2;
    
    public Text puntText;
   

    // Start is called before the first frame update
    void Start()
    {
        win.gameObject.SetActive(false);
        restart2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            win.gameObject.SetActive(true);
            restart2.gameObject.SetActive(true);
            ScoreScript.scoreValue = ScoreScript.scoreValue * GameControl.health;
            Debug.Log(ScoreScript.scoreValue * GameControl.health + " score final");
            Debug.Log(GameControl.health+" vidas");
            
        }
    }
}
