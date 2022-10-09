using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBoard : MonoBehaviour 
{
    public Color lightCol = Color.white;
    public Color darkCol = Color.black;
    public GameObject square;

    public List<GameObject> squares = new List<GameObject>();

    public string[] ranks = { "1", "2", "3", "4", "5", "6", "7", "8"};
    public string[] files = { "a", "b", "c", "d", "e", "f", "g", "h" };

    // Start is called before the first frame update
    void Start()
    {
        for (int rank = 0; rank < 8; rank++)
        {
            for (int file = 0; file < 8; file++)
            {
                bool isLightSquare = (file + rank) % 2 != 0;

                var squareColor = (isLightSquare) ? lightCol : darkCol;
                var position = new Vector2(-3.5f + file, -3.5f + rank);

                DrawSquare(position, squareColor, (files[file]+ranks[rank]));
            }
        }
    }
    void DrawSquare (Vector2 pos, Color col, string coord)
    {
        GameObject go;
        go = Instantiate(square, pos, Quaternion.identity);
        go.name = coord;
        go.GetComponent<Renderer>().material.color = col;
        squares.Add(go);
    }
    
}
