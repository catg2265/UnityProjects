using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void EndGame()
    {
        Application.Quit();
    }
    public void Respawn()
    {
        if (GameObject.Find("Player") == null) 
        {
            GameObject go = Instantiate(playerPrefab, new Vector3(-9.36f, -1.5f, 0f), Quaternion.identity);
            go.GetComponent<BoxCollider2D>().enabled = true;
            go.GetComponent<Animator>().enabled = true;
            go.GetComponent<PlayerMovement>().enabled = true;
            go.GetComponent<SpriteRenderer>().enabled = true;
            go.transform.localScale = new Vector3(1f, 1f, 1f);
            go.name = "Player";
        }
    }
}
