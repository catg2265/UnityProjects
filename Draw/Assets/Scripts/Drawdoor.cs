using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawdoor : MonoBehaviour
{
    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.startColor = new Color32(0, 0, 255, 255);
        line.endColor = new Color32(255, 255, 0, 255);
        line.positionCount = 3;
        line.SetPosition(0, new Vector3(0, 0, 0));
        line.SetPosition(1, new Vector3(1, 0, 0));
        line.SetPosition(2, new Vector3(1, 2, 0));

    }
}
