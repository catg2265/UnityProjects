using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPieces : MonoBehaviour
{
    public GameObject whiteKing;
    public GameObject whiteQueen;
    public GameObject whiteRook;
    public GameObject whiteBishop;
    public GameObject whiteKnight;
    public GameObject whitePawn;
    public GameObject blackKing;
    public GameObject blackQueen;
    public GameObject blackRook;
    public GameObject blackBishop;
    public GameObject blackKnight;
    public GameObject blackPawn;
    public GameObject[] whitePieces = new GameObject[6];
    public GameObject[] blackPieces = new GameObject[6];

    public int offset = 7;

    GameObject go;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        initializePieces();
        var squareList = GameObject.Find("Board").GetComponent<DrawBoard>().squares;
        for (int rank = 0; rank < 8; rank++)
        {
            for (int file = 0; file < 8; file++)
            {
                if (rank == 0 || rank == 1)
                {
                    if (rank == 1)
                    {
                        go = Instantiate(whitePieces[5], new Vector2 (squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                        go.name = "Pawn " + squareList[rank + file + offset * rank].name;
                    }
                    else
                    {
                        if (file == 0 || file == 7)
                        {
                            go = Instantiate(whitePieces[2], new Vector2(squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                            go.name = "Rook " + squareList[rank + file + offset * rank].name;
                        }
                        if (file == 1 || file == 6)
                        {
                            go = Instantiate(whitePieces[4], new Vector2(squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                            go.name = "Knight " + squareList[rank + file + offset * rank].name;
                        }
                        if (file == 2 || file == 5)
                        {
                            go = Instantiate(whitePieces[3], new Vector2(squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                            go.name = "Bishop " + squareList[rank + file + offset * rank].name;
                        }
                        if (file == 3)
                        {
                            go = Instantiate(whitePieces[1], new Vector2(squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                            go.name = "Queen " + squareList[rank + file + offset * rank].name;
                        }
                        if (file == 4)
                        {
                            go = Instantiate(whitePieces[0], new Vector2(squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                            go.name = "King " + squareList[rank + file + offset * rank].name;
                        }
                    }
                }
                if (rank == 6 || rank == 7)
                {
                    if (rank == 6)
                    {
                        go = Instantiate(blackPieces[5], new Vector2(squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                        go.GetComponent<pawn>().color = 1;
                        go.name = "Pawn " + squareList[rank + file + offset * rank].name;
                    }
                    else
                    {
                        if (file == 0 || file == 7)
                        {
                            go = Instantiate(blackPieces[2], new Vector2(squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                            go.GetComponent<rook>().color = 1;
                            go.name = "Rook " + squareList[rank + file + offset * rank].name;
                        }
                        if (file == 1 || file == 6)
                        {
                            go = Instantiate(blackPieces[4], new Vector2(squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                            go.GetComponent<knight>().color = 1;
                            go.name = "Knight " + squareList[rank + file + offset * rank].name;
                        }
                        if (file == 2 || file == 5)
                        {
                            go = Instantiate(blackPieces[3], new Vector2(squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                            go.GetComponent<bishop>().color = 1;
                            go.name = "Bishop " + squareList[rank + file + offset * rank].name;
                        }
                        if (file == 3)
                        {
                            go = Instantiate(blackPieces[1], new Vector2(squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                            go.GetComponent<queen>().color = 1;
                            go.name = "Queen " + squareList[rank + file + offset * rank].name;
                        }
                        if (file == 4)
                        {
                            go = Instantiate(blackPieces[0], new Vector2(squareList[rank + file + offset*rank].transform.position.x, squareList[rank + file + offset*rank].transform.position.y), Quaternion.identity);
                            go.GetComponent<king>().color = 1;
                            go.name = "King " + squareList[rank + file + offset * rank].name;
                        }
                    }
                }
            }
        }
    }
    void initializePieces()
    {
        whitePieces[0] = whiteKing;
        whitePieces[1] = whiteQueen;
        whitePieces[2] = whiteRook;
        whitePieces[3] = whiteBishop;
        whitePieces[4] = whiteKnight;
        whitePieces[5] = whitePawn;
        blackPieces[0] = blackKing;
        blackPieces[1] = blackQueen;
        blackPieces[2] = blackRook;
        blackPieces[3] = blackBishop;
        blackPieces[4] = blackKnight;
        blackPieces[5] = blackPawn;
    }
}
