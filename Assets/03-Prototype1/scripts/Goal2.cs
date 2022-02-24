using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal2 : MonoBehaviour
{
    static public bool 	goalMet = false;
/*
    void OnCollisonStay(Collision other) {
        // when collision is hit by Player
        if (other.gameObject.tag == "Player") {
            goal.goalMet = true;

            // also set the alpha of the color of higher opacity
			Material mat = GetComponent<Renderer>().material;
			Color c = mat.color;
			c.a = 1;
			mat.color = c;
        }
    }
*/
    void OnTriggerEnter(Collider other) {
        // when collision is hit by Player
        if (other.gameObject.tag == "Player") {
            Goal2.goalMet = true;
/*
            // also set the alpha of the color of higher opacity
			Material mat = GetComponent<Renderer>().material;
			Color c = mat.color;
			c.a = 1;
			mat.color = c;
*/
        }
    }
}
