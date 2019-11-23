using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: ----" + scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: "+scoreValue.ToString();
    }
}

