using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector3[] positions;
    int i;

    void Start()
    {
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localscale = transform.localScale;
        transform.position = Vector3.MoveTowards(transform.position, positions[i], Time.deltaTime * speed);
        if (transform.position == positions[i])
        { 
            if (i == positions.Length - 1)
            {
                i = 0;
                localscale.x *= -1f;
                transform.localScale = localscale;
            }

            else
            {
                i++;
                localscale.x *= -1f;
                transform.localScale = localscale;
            }
        }
    }
}
