 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameControl : MonoBehaviour
{

    public GameObject heart1, heart2, heart3, gameOver, restartButton, lose1, lose2, lose3;

    public static double health;

    public static GameControl instance;

    public GameObject player;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        lose1.gameObject.SetActive(false);
        lose2.gameObject.SetActive(false);
        lose3.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);

                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                
                if (ScoreScript.scoreValue <= 200)
                    lose1.gameObject.SetActive(true);
                if (ScoreScript.scoreValue <= 500 && ScoreScript.scoreValue > 200)
                    lose2.gameObject.SetActive(true);
                if (ScoreScript.scoreValue <= 1000 && ScoreScript.scoreValue > 500)
                    lose3.gameObject.SetActive(true);
                Time.timeScale = 0f;
                break;
        }
    }
}
