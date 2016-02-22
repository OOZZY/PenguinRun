using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    public static int score;        // The player's score.
    Text text;                      // Reference to the Text component.

    public static float scoreCount;
    public static float highscoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();
        score = 0;
    }


    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highscoreCount)
        {
            highscoreCount = scoreCount;
        }

        //scoreText.text = "" + Mathf.Round(scoreCount);
        //highscoreText.text = "" + Mathf.Round(highscoreCount);
        text.text = "Score: " + Mathf.Round(scoreCount); ;
    }
}
