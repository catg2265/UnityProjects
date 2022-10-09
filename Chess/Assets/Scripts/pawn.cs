using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawn : MonoBehaviour
{
    public GameObject posMoveIndicator;
    public GameObject go;
    GameObject[] goArray;

    public int color = 0;
    bool hasMoved = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        var squareList = GameObject.Find("Board").GetComponent<DrawBoard>().squares;
    }

    // Update is called once per frame
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            goArray = GameObject.FindGameObjectsWithTag("posMove");
            foreach (GameObject go in goArray)
            {
                Destroy(go);
            }
            possibleMoves();
        }
    }
    void possibleMoves()
    {
        if (color == 0)
        {
            if (hasMoved)
            {

            }
            else
            {
                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = true;
                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = true;
               /* if (GetComponentInChildren<DiagCheck>().check)
                {
                    go = Instantiate(posMoveIndicator, new Vector2(transform.position.x + 1, transform.position.y + 1), Quaternion.identity);
                    go.GetComponent<posMoveObject>().isWhite = true;
                }*/
            }
        }
        else
        {
            if (hasMoved)
            {

            }
            else
            {
                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = false;
                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x, transform.position.y - 2), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = false;
                /*if (GetComponentInChildren<DiagCheck>().check)
                {
                    go = Instantiate(posMoveIndicator, new Vector2(transform.position.x - 1, transform.position.y - 1), Quaternion.identity);
                    go.GetComponent<posMoveObject>().isWhite = false;
                }*/
            }
        }
        
    }
}
