using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    public float squishAngle = 30f;

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Sin(Time.time) * squishAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
