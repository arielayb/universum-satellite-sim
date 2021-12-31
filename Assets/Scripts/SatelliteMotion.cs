using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SatelliteMotion : MonoBehaviour
{
    public Transform target;
    public Slider rotateX;
    public Slider rotateY;
    public Slider rotateZ;
    public Slider slerpVal;

    // orbit around the object using quaternion slerp
    void OrbitSlerp() {
        Vector3 relativePos = (target.position + new Vector3(0, 1.5f, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        transform.Translate(slerpVal.value * Time.deltaTime, 0, 0);
    }

    void RotateSat() {
        transform.Rotate(rotateX.value, rotateY.value, rotateZ.value);
    }

    void FixedUpdate()
    {
        OrbitSlerp();
        RotateSat();

    }
}