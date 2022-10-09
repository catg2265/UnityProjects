using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int i = 0;
    public Vector3[] positions;
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = ComputeNextPosition(this.gameObject.transform.position);
    }

    Vector3 ComputeNextPosition (Vector3 position)
    {
        position = Vector3.MoveTowards(position, positions[i], Time.deltaTime * speed);
        if (transform.position == positions[i])
        {
            if (i == positions.Length - 1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }
        return position;
    }
}
