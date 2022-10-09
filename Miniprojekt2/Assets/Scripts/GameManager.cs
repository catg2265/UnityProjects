using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region values
    public static int[] cRange = { 15000, 30000 };
    public static int[] hRange = { 5000, 14000 };
    public static int[] aRange = { 1000, 4500 };
    public static int[] wRange = { 300, 900 };
    public static int[] sRange = { 70, 250 };
    public static int[] lRange = { 10, 60 };

    City br, gh, ce, ma, co, b;

    List<City> cityList = new List<City>();

    [SerializeField] GameObject prefab;

    int currentDay = 0;

    public bool onTrigger = false;
    public string triggerName;
    #endregion
    void Start()
    {
        br = new City("Bronx", Instantiate(prefab, new Vector2(-5, 2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        gh = new City("Ghetto", Instantiate(prefab, new Vector2(0, 2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        ce = new City("Central Park", Instantiate(prefab, new Vector2(5, 2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        ma = new City("Manhattan", Instantiate(prefab, new Vector2(-5, -2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        co = new City("Coney Island", Instantiate(prefab, new Vector2(0, -2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        b = new City("Brooklyn", Instantiate(prefab, new Vector2(5, -2), Quaternion.identity), RandValue(cRange), RandValue(hRange), RandValue(aRange), RandValue(wRange), RandValue(sRange), RandValue(lRange));
        cityList.Add(br); cityList.Add(gh); cityList.Add(ce); cityList.Add(ma); cityList.Add(co); cityList.Add(b);
        foreach (City element in cityList)
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
        onTrigger = false;
        triggerName = null;
    }
    int RandValue(int[] range)
    {
        return Random.Range(range[0], range[1]);
    }
    void RefreshValues (bool triggered, string name)
    {
        if (triggered)
        {
            currentDay++;
            foreach (City element in cityList)
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
                    Debug.Log(currentDay.ToString());
                }
            }
        }
    }
}
public class City
{
    public GameObject go;
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
        ob.GetComponentInChildren<TextMeshPro>().text = cityName;
    }
}