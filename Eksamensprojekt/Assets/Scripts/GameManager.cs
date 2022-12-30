using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region PreStart

    #region Values
    private const float InitialSpawnRate = 2;
    private float timer = 0;
    public float spawnRate;
    
    private int obstacleAmount = 1;
    private int rotindex;
    private int totCount;
    
    public bool GameStart = false;
    public bool EndScreenActivate = false;
    private bool spawnFirstRoundOnlyOnce = true;
    [SerializeField] private bool UseGameObjects = true;
    
    private static string scoreText = "Score: ";
    private static string highText = "Highscore: ";
    
    [SerializeField] private List<Vector3> possibleRotations = new List<Vector3>();
    private Vector3 obstacleExtraRotation = new Vector3(0, 60, 0);
    #endregion

    #region ObjectsAndText
    [SerializeField] private List<TextMeshProUGUI> scoresTextList = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> collectibleTextList = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> EndScreenTextList = new List<TextMeshProUGUI>();

    [SerializeField] private GameObject Obstacle;
    [SerializeField] private GameObject Collectible1;
    [SerializeField] private GameObject Collectible2;
    [SerializeField] private GameObject EndScreenObject;
    #endregion

    #region ClassValues
    private Collectibles collectible1;
    private Collectibles collectible2;
    private Collectibles obstacle;

    private Collectibles[] CollectiblesArray = new Collectibles[3];

    public PlayerScore player;
    #endregion
    
    #endregion
    // Start is called before the first frame update
    private void Start()
    {
        if (!UseGameObjects)
        {
            Obstacle = null; Collectible1 = null; Collectible2 = null; EndScreenObject = null;
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
            spawnRate = InitialSpawnRate;
            EndScreenTextList[0].enabled = false;
            EndScreenObject.SetActive(false);
            
        }
    }
    // Update is called once per frame
    private void Update()
    {
        if (UseGameObjects && GameStart)
        { 
            PlayerScore();
            totCount = player.collectible1Count + player.collectible2Count;
            Spawner();
            timer += Time.deltaTime;
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
    }
    private void Spawner()
    {
        if (timer > spawnRate)
        {
            timer = 0;
            InstantiateRound();
        }
    }
    private void PlayerScore()
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
    }
    private GameObject InstatiateCollectible()
    {
        GameObject prefab = CollectiblesArray[Random.Range(0, 2)].prefab;
        return Instantiate(prefab, prefab.transform.position, Quaternion.identity );
    }
    public void EndScreen()
    {
        GameStart = false;
        EndScreenActivate = true;
        foreach (var o in GameObject.FindGameObjectsWithTag("Spawnable")) Destroy(o);
        EndScreenObject.SetActive(true);
        EndScreenTextList[1].text = "Your score was: " + player.totalScore.ToString();
        if (player.totalScore == PlayerPrefs.GetInt("Highscore"))
        {
            EndScreenTextList[0].enabled = true;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
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
