using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handler : MonoBehaviour {
    // Update is called once per frame
    void Update()
    {
        Vector3 vec3 = this.transform.eulerAngles;
        vec3.y += 20 * Time.deltaTime;
        vec3.y %= 360;
        this.transform.eulerAngles = vec3;
    }
}

