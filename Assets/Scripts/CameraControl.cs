using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public Slider zoom;
    public Camera main;
    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        main.transform.TransformDirection(zoom.value, 0.0f, 0.0f);
        main.transform.LookAt(Target);
    }
}
