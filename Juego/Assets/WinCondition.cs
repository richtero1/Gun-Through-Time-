using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{

    public GameObject win, restart2;
    
    public Text puntText;
    double punt = ScoreScript.scoreValue * GameControl.health;
   

    // Start is called before the first frame update
    void Start()
    {
        win.gameObject.SetActive(false);
        restart2.gameObject.SetActive(false);
        puntText.text = "Score Final: " + punt.ToString();
        puntText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        puntText.text = "Score Final: " + punt.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            win.gameObject.SetActive(true);
            restart2.gameObject.SetActive(true);
            
            puntText.gameObject.SetActive(true);
            Debug.Log(ScoreScript.scoreValue);
            Debug.Log(GameControl.health);
            Debug.Log(punt);
        }
    }
}
