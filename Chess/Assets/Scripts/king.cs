using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class king : MonoBehaviour
{
    public GameObject posMoveIndicator;
    public int color = 0;
    GameObject[] goArray;
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

    }
}
