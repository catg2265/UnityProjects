using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int InitialSpawnRate = 1;

    [SerializeField] private float StartDelay = 1f;

    private static string scoreText = "Score: ";
    private static string highText = "Highscore: ";
    
    [SerializeField] private List<TextMeshProUGUI> scoresTextList = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> collectibleTextList = new List<TextMeshProUGUI>();

    [SerializeField] private GameObject Obstacle;
    [SerializeField] private GameObject Collectible1;
    [SerializeField] private GameObject Collectible2;
    
    private Collectibles collectible1;
    private Collectibles collectible2;
    private Collectibles obstacle;

    private Collectibles[] CollectiblesArray = new Collectibles[3];

    public PlayerScore player;

    [SerializeField] private bool UseGameObjects = true;
    public bool FirstCol = false;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (!UseGameObjects)
        {
            Obstacle = null; Collectible1 = null; Collectible2 = null;
        }
        else
        {
            collectible1 = new Collectibles(Collectible1, 500);
            collectible2 = new Collectibles(Collectible2, 1000);
            obstacle = new Collectibles(Obstacle, 0);
            player = new PlayerScore();
            CollectiblesArray[0] = collectible1; CollectiblesArray[1] = collectible2; CollectiblesArray[2] = obstacle;
            scoresTextList[0].text = scoreText + "0";
            scoresTextList[1].text = highText + PlayerPrefs.GetInt("HighScore", 0);
            collectibleTextList[0].text = "0";
            yield return new WaitForSeconds(StartDelay);
            //Instantiate first round
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UseGameObjects)
        {
            if (player.totalScore > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", player.totalScore);
            }
            if (UseGameObjects && FirstCol)
            {
                player.totalScore = (player.collectible1Count * collectible1.points) +
                                    (player.collectible2Count * collectible2.points);
                scoresTextList[0].text = scoreText + player.totalScore.ToString();
                scoresTextList[1].text = highText + PlayerPrefs.GetInt("HighScore", 0);
                //Start spawning at increasing rate
                //Start increasing difficulty (add more obstacles)
            }
        }
    }

    private Vector3 RandRotation()
    {
        return new Vector3(0,Random.Range(0, 359),0) ;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

public class PlayerScore
{
    public int totalScore;
    public int collectible1Count;
    public int collectible2Count;
    public PlayerScore()
    {
        totalScore = 0;
        collectible1Count = 0;
        collectible2Count = 0;
    }
}

public class Collectibles
{
    public GameObject prefab;
    public int points;
    public Collectibles(GameObject go, int pnt)
    {
        prefab = go;
        points = pnt;
    }
}
