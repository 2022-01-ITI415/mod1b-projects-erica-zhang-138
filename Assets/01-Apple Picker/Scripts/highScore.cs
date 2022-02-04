using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    static public int    score = 10;

    void Awake() {
        // If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("highScore")) {
            score = PlayerPrefs.GetInt("highScore");
        }
        // Assign the high score to HighScore
        PlayerPrefs.SetInt("highScore", score);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: "+score;
    }
}
