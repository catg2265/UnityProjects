using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject go;
    private GameObject[,,] goArray = new GameObject[10,10,10];
    private float offset = 5f;
    private Color[] colors = {Color.red, Color.blue};
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    goArray[i,j,k] = Instantiate(go, new Vector3(0 + i - offset, 0 + j - offset, 0 + k - offset), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    var renderer = goArray[i, j, k].GetComponent<MeshRenderer>();
                    /*if ((i+j+k) % 2 == 0)
                    {
                        renderer.material.SetColor("_Color", Color.red);
                    }
                    if ((i + j + k) % 2 != 0)
                    {
                        renderer.material.SetColor("_Color", Color.blue);
                    }*/
                    if (Random.Range(0, 100) == 1)
                    {
                        renderer.material.SetColor("_Color", colors[Random.Range(0, 2)]);
                    }
                }
            }
        }
    }
}
