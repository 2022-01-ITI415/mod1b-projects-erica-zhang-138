using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    public static float bottomY = -20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY) {
            Destroy(this.gameObject);

            // Get a reference to the ApplePicker component of Main Camera
            applePicker apScript = Camera.main.GetComponent<applePicker>();
            // Call the public AppleDestroyed() method of apScript
            apScript.AppleDestroyed();
        }   
    }
}
