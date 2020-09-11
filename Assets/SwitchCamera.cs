using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Camera menuCamera;
    void Start()
    {
        menuCamera = GameObject.Find("MenuCamera").GetComponent<Camera>();
        menuCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
