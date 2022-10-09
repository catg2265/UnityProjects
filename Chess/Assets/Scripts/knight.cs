using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : MonoBehaviour
{
    public GameObject posMoveIndicator;
    GameObject go;
    public  int color = 0;
    GameObject[] goArray;
    public float boundary = -3.5f;

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
            if (transform.position.x + 1 >= boundary && transform.position.x + 1 <= Mathf.Abs(boundary) && transform.position.y + 2 >= boundary && transform.position.y + 2 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x + 1, transform.position.y + 2), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = true;

            }

            if (transform.position.x - 1 >= boundary && transform.position.x - 1 <= Mathf.Abs(boundary) && transform.position.y + 2 >= boundary && transform.position.y + 2 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x - 1, transform.position.y + 2), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = true;

            }

            if (transform.position.x + 2 >= boundary && transform.position.x + 2 <= Mathf.Abs(boundary) && transform.position.y + 1 >= boundary && transform.position.y + 1 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x + 2, transform.position.y + 1), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = true;

            }

            if (transform.position.x + 2 >= boundary && transform.position.x + 2 <= Mathf.Abs(boundary) && transform.position.y - 1 >= boundary && transform.position.y - 1 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x + 2, transform.position.y - 1), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = true;

            }

            if (transform.position.x + 1 >= boundary && transform.position.x + 1 <= Mathf.Abs(boundary) && transform.position.y - 2 >= boundary && transform.position.y - 2 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x + 1, transform.position.y - 2), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = true;

            }

            if (transform.position.x - 1 >= boundary && transform.position.x - 1 <= Mathf.Abs(boundary) && transform.position.y - 2 >= boundary && transform.position.y - 2 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x - 1, transform.position.y - 2), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = true;

            }

            if (transform.position.x - 2 >= boundary && transform.position.x - 2 <= Mathf.Abs(boundary) && transform.position.y + 1 >= boundary && transform.position.y + 1 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x - 2, transform.position.y + 1), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = true;

            }

            if (transform.position.x - 2 >= boundary && transform.position.x - 2 <= Mathf.Abs(boundary) && transform.position.y - 1 >= boundary && transform.position.y - 1 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x - 2, transform.position.y - 1), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = true;

            }
        }
        else
        {
            if (transform.position.x + 1 >= boundary && transform.position.x + 1 <= Mathf.Abs(boundary) && transform.position.y + 2 >= boundary && transform.position.y + 2 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x + 1, transform.position.y + 2), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = false;

            }

            if (transform.position.x - 1 >= boundary && transform.position.x - 1 <= Mathf.Abs(boundary) && transform.position.y + 2 >= boundary && transform.position.y + 2 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x - 1, transform.position.y + 2), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = false;

            }

            if (transform.position.x + 2 >= boundary && transform.position.x + 2 <= Mathf.Abs(boundary) && transform.position.y + 1 >= boundary && transform.position.y + 1 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x + 2, transform.position.y + 1), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = false;

            }

            if (transform.position.x + 2 >= boundary && transform.position.x + 2 <= Mathf.Abs(boundary) && transform.position.y - 1 >= boundary && transform.position.y - 1 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x + 2, transform.position.y - 1), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = false;

            }

            if (transform.position.x + 1 >= boundary && transform.position.x + 1 <= Mathf.Abs(boundary) && transform.position.y - 2 >= boundary && transform.position.y - 2 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x + 1, transform.position.y - 2), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = false;

            }

            if (transform.position.x - 1 >= boundary && transform.position.x - 1 <= Mathf.Abs(boundary) && transform.position.y - 2 >= boundary && transform.position.y - 2 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x - 1, transform.position.y - 2), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = false;

            }

            if (transform.position.x - 2 >= boundary && transform.position.x - 2 <= Mathf.Abs(boundary) && transform.position.y + 1 >= boundary && transform.position.y + 1 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x - 2, transform.position.y + 1), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = false;

            }

            if (transform.position.x - 2 >= boundary && transform.position.x - 2 <= Mathf.Abs(boundary) && transform.position.y - 1 >= boundary && transform.position.y - 1 <= Mathf.Abs(boundary))
            {

                go = Instantiate(posMoveIndicator, new Vector2(transform.position.x - 2, transform.position.y - 1), Quaternion.identity);
                go.GetComponent<posMoveObject>().isWhite = false;

            }
        }
    }
}
