using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region values
    
    private static int[] cRange = { 15000, 30000 };
    private static int[] hRange = { 5000, 14000 };
    private static int[] aRange = { 1000, 4500 };
    private static int[] wRange = { 300, 900 };
    private static int[] sRange = { 70, 250 };
    private static int[] lRange = { 10, 60 };

    private City _br, _gh, _ce, _ma, _co, _b;

    private List<City> _cityList = new List<City>();

    [SerializeField] private GameObject prefab;
    [SerializeField] private TextMeshPro shop;
    

    private int _currentDay = 0;

    public bool onTrigger = false;
    public string triggerName;
    #endregion
    void Start()
    {
        _br = new City("Bronx", Instantiate(prefab, new Vector2(-5, 2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        _gh = new City("Ghetto", Instantiate(prefab, new Vector2(0, 2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        _ce = new City("Central Park", Instantiate(prefab, new Vector2(5, 2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        _ma = new City("Manhattan", Instantiate(prefab, new Vector2(-5, -2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        _co = new City("Coney Island", Instantiate(prefab, new Vector2(0, -2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        _b = new City("Brooklyn", Instantiate(prefab, new Vector2(5, -2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        _cityList.Add(_br); _cityList.Add(_gh); _cityList.Add(_ce); _cityList.Add(_ma); _cityList.Add(_co); _cityList.Add(_b);
        foreach (City element in _cityList)
        {
            Debug.Log(element.cityName + " Cocaine " + element.cocaine.ToString());
            Debug.Log(element.cityName + " Heroin " + element.heroin.ToString());
            Debug.Log(element.cityName + " Acid " + element.acid.ToString());
            Debug.Log(element.cityName + " Weed " + element.weed.ToString());
            Debug.Log(element.cityName + " Speed " + element.speed.ToString());
            Debug.Log(element.cityName + " Ludes " + element.ludes.ToString());
        }
    }
    private void Update()
    {
        RefreshValues(onTrigger, triggerName);
    }
    int RandValue(int[] range)
    {
        return Random.Range(range[0], range[1]);
    }
    void RefreshValues (bool triggered, string name)
    {
        if (triggered)
        {
            _currentDay++;
            foreach (City element in _cityList)
            {
                if (element.cityName.Contains(name))
                {
                    element.cocaine = RandValue(cRange);
                    element.heroin = RandValue(hRange);
                    element.acid = RandValue(aRange);
                    element.weed = RandValue(wRange);
                    element.speed = RandValue(sRange);
                    element.ludes = RandValue(lRange);
                    Debug.Log(element.cityName + " Cocaine " + element.cocaine.ToString());
                    Debug.Log(element.cityName + " Heroin " + element.heroin.ToString());
                    Debug.Log(element.cityName + " Acid " + element.acid.ToString());
                    Debug.Log(element.cityName + " Weed " + element.weed.ToString());
                    Debug.Log(element.cityName + " Speed " + element.speed.ToString());
                    Debug.Log(element.cityName + " Ludes " + element.ludes.ToString());
                    Debug.Log(_currentDay.ToString());
                }
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
    public void DisplayValues(TextMeshPro textPrice, TextMeshPro textInv)
    {
        textPrice.text = "Do you want to buy, sell or jet?" +
                         $"\n Cocaine = {cocaine}" +
                         $"\n Heroin = {heroin}" +
                         $"\n Acid = {acid}" +
                         $"\n Weed = {weed}" +
                         $"\n Speed = {speed}" +
                         $"\n Ludes = {ludes}";
        textInv.text = "Your Inventory" +
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
    public int cocaineAmount;
    public int heroinAmount;
    public int acidAmount;
    public int weedAmount;
    public int speedAmount;
    public int ludesAmount;
    public bool hasGun = false;
    public int cash;
    public int debt;
    public Player(int startCash, int startDebt)
    {
        cash = startCash;
        debt = startDebt;
    }
}