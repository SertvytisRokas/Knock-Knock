using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Camera menuCamera;
    AudioListener audioListener;
    
    void Start()
    {
        menuCamera = GameObject.Find("MenuCamera").GetComponent<Camera>();
        menuCamera.enabled = false;
        audioListener = menuCamera.GetComponent<AudioListener>();
        audioListener.enabled = false;
        Camera thisCamera = this.GetComponentInChildren<Camera>();
        thisCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
