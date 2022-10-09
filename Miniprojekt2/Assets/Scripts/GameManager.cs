using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

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
    #endregion
    #region classValues
    private City _br, _gh, _ce, _ma, _co, _b;
    private Player _player;

    private List<City> _cityList = new List<City>();
    #endregion
    #region GameObjects
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject msgBox;
    [SerializeField] private GameObject UI;
    #endregion
    
    private int _currentDay = 0;

    public bool onTrigger = false;
    public string triggerName;
    
    #endregion
    void Start()
    {
        UI.SetActive(false);
        _player = new Player(StartingCash, StartingDebt);
        _br = new City("Bronx", Instantiate(prefab, new Vector2(-5, 2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _gh = new City("Ghetto", Instantiate(prefab, new Vector2(0, 2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _ce = new City("Central Park", Instantiate(prefab, new Vector2(5, 2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _ma = new City("Manhattan", Instantiate(prefab, new Vector2(-5, -2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _co = new City("Coney Island", Instantiate(prefab, new Vector2(0, -2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _b = new City("Brooklyn", Instantiate(prefab, new Vector2(5, -2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _cityList.Add(_br); _cityList.Add(_gh); _cityList.Add(_ce); _cityList.Add(_ma); _cityList.Add(_co); _cityList.Add(_b);
        /*      foreach (City element in _cityList)
              {
                  Debug.Log(element.cityName + " Cocaine " + element.cocaine.ToString());
                  Debug.Log(element.cityName + " Heroin " + element.heroin.ToString());
                  Debug.Log(element.cityName + " Acid " + element.acid.ToString());
                  Debug.Log(element.cityName + " Weed " + element.weed.ToString());
                  Debug.Log(element.cityName + " Speed " + element.speed.ToString());
                  Debug.Log(element.cityName + " Ludes " + element.ludes.ToString());
              }*/
    }
    private void Update()
    {
        if (onTrigger)
        {
            UI.SetActive(true);
            RefreshValues(triggerName);
        }
    }
    int RandValue(int[] range)
    {
        return Random.Range(range[0], range[1]);
    }
    void RefreshValues (string name)
    {
        _currentDay++;
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
                //shop.GetComponent<TextMeshPro>().text = element.DisplayPrice();
                //inv.GetComponent<TextMeshPro>().text = _player.DisplayInventory();
            }
        }
    }
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
    public int cocaineAmount = 0;
    public int heroinAmount = 0;
    public int acidAmount = 0;
    public int weedAmount = 0;
    public int speedAmount = 0;
    public int ludesAmount = 0;
    public bool hasGun = false;
    public int cash;
    public int debt;
    public Player(int startCash, int startDebt)
    {
        cash = startCash;
        debt = startDebt;
    }
    public string DisplayInventory()
    {
        return "Inventory: \n" +
                       $"\n Cocaine = {cocaineAmount}" +
                       $"\n Heroin = {heroinAmount}" +
                       $"\n Acid = {acidAmount}" +
                       $"\n Weed = {weedAmount}" +
                       $"\n Speed = {speedAmount}" +
                       $"\n Ludes = {ludesAmount}" +
                       $"\n HaveGun = {hasGun}" +
                       $"\n Cash = {cash}" +
                       $"\n Debt = {debt}";
    }
}