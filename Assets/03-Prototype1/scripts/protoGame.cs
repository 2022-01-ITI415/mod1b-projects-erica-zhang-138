using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode {
        idle,
        playing,
        levelEnd
    }

public class protoGame : MonoBehaviour
{
    static private protoGame P;

    [Header("Set in Inspector")]
    public Text uitLevel;  // The UIText_Level Text
    public Text uitButton; // The Text on UIButton_View
    public Vector3 levelPos; // The place to put level
    public GameObject[] levels;   // An array of the levels


    [Header("Set Dynamically")]
    public int lvl;     // The current level
    public int lvlMax;  // The number of levels

    public GameObject level; // The current level
    public GameMode mode = GameMode.idle;

    void Start() {
        P = this;
        lvl = 0;
        lvlMax = levels.Length;
        StartLevel();
    }

    void StartLevel() {
        // Get rid of the old level if one exists
        if (level != null) {
            Destroy(level);
        }

        // Destroy old players if they exist
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject pTemp in gos) {
            Destroy(pTemp);
        }

        // Instantiate the new level
        level = Instantiate<GameObject>(levels[level]);
        level.transform.position = levelPos;

        // Reset the goal
        Goal.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }

    void UpdateGUI() {
        // Show the data in the GUITexts
        uitLevel.text = "Level: " + (lvl + 1) + " of " + lvlMax;
    }

    void Update() {
        // Check for level end
        if ((mode == GameMode.playing) && Goal.goalMet) {
            // Change mode to stop checking for level end
            mode = GameMode.levelEnd;

            // Start the next level in 2 seconds
            Invoke("NextLevel", 2f);
        }
    }
    void NextLevel() {
        lvl++;
        if (lvl == lvlMax) {
            lvl = 0;
        }
        StartLevel();

    }
}
