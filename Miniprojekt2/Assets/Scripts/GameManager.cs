using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Values

    #region constValues
    private const int StartingCash = 2000;
    private const int StartingDebt = 5500;

    private static int[] _cRange = { 15000, 30000 };
    private static int[] _hRange = { 5000, 14000 };
    private static int[] _aRange = { 1000, 4500 };
    private static int[] _wRange = { 300, 900 };
    private static int[] _sRange = { 70, 250 };
    private static int[] _lRange = { 10, 60 };

    private static int[] _percent = { 1, 100 };

    #endregion
    #region classValues
    private City _br, _gh, _ce, _ma, _co, _b;
    private Player _player;

    private List<City> _cityList = new List<City>();
    #endregion
    #region GameObjects
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject CityUI;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject GoodEnd;
    [SerializeField] private GameObject BadEnd;
    [SerializeField] private TextMeshProUGUI CurrentDayText;
    [SerializeField] private TextMeshProUGUI shopText;
    [SerializeField] private TextMeshProUGUI invText;
    #endregion
    
    private int _currentDay = 0;

    public bool onTrigger = false;
    public string triggerName;
    
    #endregion
    void Start()
    {
        Jet();
        GoodEnd.SetActive(false);
        BadEnd.SetActive(false);
        _player = new Player(StartingCash, StartingDebt);
        _br = new City("Bronx", Instantiate(prefab, new Vector2(-5, 2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _gh = new City("Ghetto", Instantiate(prefab, new Vector2(0, 2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _ce = new City("Central Park", Instantiate(prefab, new Vector2(5, 2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _ma = new City("Manhattan", Instantiate(prefab, new Vector2(-5, -2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _co = new City("Coney Island", Instantiate(prefab, new Vector2(0, -2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _b = new City("Brooklyn", Instantiate(prefab, new Vector2(5, -2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _cityList.Add(_br); _cityList.Add(_gh); _cityList.Add(_ce); _cityList.Add(_ma); _cityList.Add(_co); _cityList.Add(_b);
    }
    private void Update()
    {
        if (_currentDay != 30)
        {
            if (onTrigger)
            {
                UI.SetActive(false);
                CityUI.SetActive(true);
                RefreshValues(triggerName);
            }
        }
        else
        {
            if (_player.debt != 0)
            {
                BadEnd.SetActive(true);
            }
            else
            {
                GoodEnd.SetActive(true);
            }
        }
    }

    #region functions
    int RandValue(int[] range)
    {
        return Random.Range(range[0], range[1]);
    }
    void RefreshValues (string name)
    {
        foreach (City element in _cityList)
        {
            if (element.cityName.Contains(name))
            {
                element.cocaine = RandValue(_cRange);
                element.heroin = RandValue(_hRange);
                element.acid = RandValue(_aRange);
                element.weed = RandValue(_wRange);
                element.speed = RandValue(_sRange);
                element.ludes = RandValue(_lRange);
                shopText.text = element.DisplayPrice();
                invText.text = _player.DisplayInventory();
            }
        }

        onTrigger = false;
    }
    public void Jet()
    {
        CityUI.SetActive(false);
        UI.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovemement>().canMove = true;
        _currentDay++;
        CurrentDayText.text = "Day: " + _currentDay.ToString();
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void GenerateCops()
    {
        //Chance to get chased by cops
        //If player has a gun the player can fight the cops
        //If player gets hit too much the player needs to be stitched together by a doctor
        //Chance needs to increase the more drugs the player has bought and sold
        if (RandValue(_percent) <= 5)
        {
            
        }
    }
    void BuyCoat()
    {
        //When entering city, there's a chance the player can buy a new coat with more inventory space
        if (RandValue(_percent) <= 10)
        {
            
        }
    }
    void BuyGun()
    {
        //When entering city, there's a chance the player can buy a gun
        if (RandValue(_percent) <= 10)
        {
            
        }
    }
    void CheaperDrugs()
    {
        //There's a chance the drugs are being sold for very little
        if (RandValue(_percent) <= 5)
        {
            
        }
    }
    void ExpensiveDrugs()
    {
        //There's a chance the drugs are being sold for a lot more than usual
        if (RandValue(_percent) <= 5)
        {
            
        }
    }
    
    #endregion
    
}
public class City
{
    private GameObject go;
    public string cityName;
    public int cocaine;
    public int heroin;
    public int acid;
    public int weed;
    public int speed;
    public int ludes;
    public City(string name, GameObject ob, int c, int h, int a, int w, int s, int l)
    {
        go = ob;
        cityName = name;
        cocaine = c;
        heroin = h;
        acid = a;
        weed = w;
        speed = s;
        ludes = l;
        go.GetComponentInChildren<TextMeshPro>().text = cityName;
    }
    public string DisplayPrice()
    {
        return "Do you want to buy, sell or jet? \n" +
               $"\n Cocaine = {cocaine}" +
               $"\n Heroin = {heroin}" +
               $"\n Acid = {acid}" +
               $"\n Weed = {weed}" +
               $"\n Speed = {speed}" +
               $"\n Ludes = {ludes}";
    }
}
public class Player
{
    
    public int cash;
    public int debt;
    public Inventory inv = new Inventory();
    public Bank bank = new Bank();
    public Player(int startCash, int startDebt)
    {
        cash = startCash;
        debt = startDebt;
    }
    public string DisplayInventory()
    {
        return "Inventory: \n" +
                       $"\n Cocaine = {inv.cocaineAmount}" +
                       $"\n Heroin = {inv.heroinAmount}" +
                       $"\n Acid = {inv.acidAmount}" +
                       $"\n Weed = {inv.weedAmount}" +
                       $"\n Speed = {inv.speedAmount}" +
                       $"\n Ludes = {inv.ludesAmount}" +
                       $"\n HaveGun = {inv.hasGun}" +
                       $"\n Cash = {cash}" +
                       $"\n Debt = {debt}";
    }
}
public class Inventory
{
    public int invSpace;
    public int cocaineAmount;
    public int heroinAmount;
    public int acidAmount;
    public int weedAmount;
    public int speedAmount;
    public int ludesAmount;
    public bool hasGun;
    public Inventory(int space = 100, int c = 0, int h = 0, int a = 0, int w = 0, int s = 0, int l = 0, bool g = false)
    {
        invSpace = space;
        cocaineAmount = c;
        heroinAmount = h;
        acidAmount = a;
        weedAmount = w;
        speedAmount = s;
        ludesAmount = l;
        hasGun = g;
    }
}

public class Bank
{
    public int money;
    public Bank(int m = 0)
    {
        money = m;
    }

    public void Withdraw(int amount)
    {
        if (money - amount !< 0)
        {
            money = money - amount;
        }
        else
        {
            
        }
    }
    public void Deposit(int amount)
    {
        money = money + amount;
    }
}