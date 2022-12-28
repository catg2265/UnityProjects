using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public float InitialSpawnRate = 2;
    public int obstacleAmount = 1;
    public int rotindex;

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

    public bool GameStart = false;
    private bool spawnFirstRoundOnlyOnce = true;

    private int totCount;

    [SerializeField] private List<Vector3> possibleRotations = new List<Vector3>();
    private Vector3 obstacleExtraRotation = new Vector3(0, 60, 0);

    // Start is called before the first frame update
    void Start()
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
            collectibleTextList[1].text = "0";
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
            player.totalScore = (player.collectible1Count * collectible1.points) +
                                (player.collectible2Count * collectible2.points);
            scoresTextList[0].text = scoreText + player.totalScore.ToString();
            scoresTextList[1].text = highText + PlayerPrefs.GetInt("HighScore", 0);
            collectibleTextList[0].text = player.collectible1Count.ToString();
            collectibleTextList[1].text = player.collectible2Count.ToString();
            totCount = player.collectible1Count + player.collectible2Count;
            
            //Start spawning at increasing rate
            
            
            if (GameStart && spawnFirstRoundOnlyOnce)
            {
                spawnFirstRoundOnlyOnce = false;
                InitiateFirstRound();
            }
        }
    }

    public void InitiateFirstRound()
    {
        GameObject go = InstatiateCollectible();
        go.transform.Rotate(possibleRotations[Random.Range(0, 5)]);
    }

    public void InstantiateRound()
    {
        if (totCount == 5 || totCount == 10 || totCount == 15 || totCount == 20)
        {
            obstacleAmount++;
        }
        List<GameObject> goList = new List<GameObject>();
        List<Vector3> rotList = new List<Vector3>();
        foreach (var element in possibleRotations)
        {
            rotList.Add(element);
        }
        goList.Add(InstatiateCollectible());
        for (int i = 0; i < obstacleAmount; i++)
        {
            goList.Add(Instantiate(CollectiblesArray[2].prefab, CollectiblesArray[2].prefab.transform.position,
                Quaternion.identity));
        }
        int index = 0;
        foreach (var VARIABLE in goList)
        {
            if (rotList.Count > 0)
            {
                rotindex = Random.Range(0, rotList.Count - 1);
            }
            else { rotindex = 0;}
            Vector3 rot = rotList[rotindex];
            if (index > 0)
            {
                VARIABLE.transform.Rotate(rot-obstacleExtraRotation);
            }
            else
            {
                VARIABLE.transform.Rotate(rot);
            }
            rotList.Remove(rot);
            index++;
        }
        //increase spawn rate
    }

    GameObject InstatiateCollectible()
    {
        GameObject prefab = CollectiblesArray[Random.Range(0, 2)].prefab;
        return Instantiate(prefab, prefab.transform.position, Quaternion.identity );
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
