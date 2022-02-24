using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class protoGame : MonoBehaviour
{
    static private protoGame P;

    [Header("Set in Inspector")]
    public Text uitLevel;  // The UIText_Level Text

    public Vector3 platPos; // The place to put plats
    public GameObject[] plats;   // An array of the plats
    public Vector3 prefabPos;
    public GameObject prefab;


    [Header("Set Dynamically")]
    public int level;     // The current level
    public int levelMax;  // The number of levels

    public GameObject plat;    // The current castle
    public GameMode mode = GameMode.idle;

    void Start() {
        P = this; // Define the Singleton
        level = 0;
        levelMax = plats.Length;
        StartLevel();
    }

    void StartLevel() {
        prefab.transform.position = prefabPos;
        
        // Get rid of the old plat if one exists
        if (plat != null) {
            Destroy(plat);
        }
/*
        // Destroy old players if they exist
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }
*/
        


        // Instantiate the new plat
        plat = Instantiate<GameObject>(plats[level]);
        plat.transform.position = platPos;

        // Instantiate the new player
        //prefab = Instantiate<GameObject>(prefab);
        prefab.transform.position = prefabPos;

        // Reset the goal
        Goal2.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }

    void UpdateGUI() {
        // Show the data in the GUITexts
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
    }

    void Update() {
        UpdateGUI();
        // Check for level end
        if ((mode == GameMode.playing) && Goal2.goalMet)
        {
            // Change mode to stop checking for level end
            mode = GameMode.levelEnd;

            // Start the next level in 2 seconds
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel() {
        level++;
        if (level == levelMax) {
            level = 0;
        }
        StartLevel();
    }
}
