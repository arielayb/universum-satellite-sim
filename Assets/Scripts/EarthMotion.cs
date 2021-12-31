using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMotion : MonoBehaviour
{
    //public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.2f * Time.deltaTime, 0);
    }
}
