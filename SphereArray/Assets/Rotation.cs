using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(0, 0, 0));
        transform.RotateAround(new Vector3(0,0,0),Vector3.up, .2f);
    }
}
