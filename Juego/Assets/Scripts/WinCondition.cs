using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{

    public GameObject win, restart2, pause;
    
    
    public Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        win.gameObject.SetActive(false);
        restart2.gameObject.SetActive(false);
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        highscore.gameObject.SetActive(false);

    }

    // Update is called once per frame

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            win.gameObject.SetActive(true);
            restart2.gameObject.SetActive(true);
            highscore.gameObject.SetActive(true);
            pause.gameObject.SetActive(false);
            ScoreScript.scoreValue = ScoreScript.scoreValue + (GameControl.health*100);

            if (ScoreScript.scoreValue > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", ScoreScript.scoreValue);
            }

            highscore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();

            Debug.Log(PlayerPrefs.GetInt("HighScore", 0) + " vidas");

            Debug.Log(ScoreScript.scoreValue * GameControl.health + " score final");
            Debug.Log(GameControl.health+" vidas");
            
        }
    }
}
