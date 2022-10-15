using System.Collections.Generic;
using System.Windows.Forms;
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

    public const string BuySellJet = "Do you want to buy, sell or jet? \n";
    public const string ShowInventory = "Inventory: \n";

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
    [SerializeField] private GameObject BuyMenu;
    [SerializeField] private GameObject SellMenu;
    [SerializeField] private GameObject VisitLoanShark;
    [SerializeField] private GameObject LoanShark;
    
    [SerializeField] private TextMeshProUGUI CurrentDayText;
    [SerializeField] private TextMeshProUGUI shopText;
    [SerializeField] private TextMeshProUGUI invText;
    [SerializeField] private TextMeshProUGUI BuypricesText;
    [SerializeField] private TextMeshProUGUI SellpricesText;
    [SerializeField] private TextMeshProUGUI invAmountText;
    [SerializeField] private TextMeshProUGUI CurrentDebt;
    [SerializeField] private TextMeshProUGUI FinalMoney;

    [SerializeField] private TMP_InputField Repay;
    [SerializeField] private TMP_InputField Borrow;
    private List<TMP_InputField> _loanShark = new List<TMP_InputField>();
    [SerializeField] private TMP_InputField BuyCocaine;
    [SerializeField] private TMP_InputField BuyHeroin;
    [SerializeField] private TMP_InputField BuyAcid;
    [SerializeField] private TMP_InputField BuyWeed;
    [SerializeField] private TMP_InputField BuySpeed;
    [SerializeField] private TMP_InputField BuyLudes;
    private List<TMP_InputField> BuyInput = new List<TMP_InputField>();
    private List<TMP_InputField> SellInput = new List<TMP_InputField>();
    [SerializeField] private TMP_InputField SellCocaine;
    [SerializeField] private TMP_InputField SellHeroin;
    [SerializeField] private TMP_InputField SellAcid;
    [SerializeField] private TMP_InputField SellWeed;
    [SerializeField] private TMP_InputField SellSpeed;
    [SerializeField] private TMP_InputField SellLudes;
    
    private List<GameObject> BuySell = new List<GameObject>();
    #endregion
    
    private int _currentDay = 0;

    public bool onTrigger = false;
    public string triggerName;

    private string lastCity;
    
    public int[] prices = new int[6]; 
    
    #endregion
    void Start()
    {
        Jet();
        GoodEnd.SetActive(false);
        BadEnd.SetActive(false);
        BuyMenu.SetActive(false);
        SellMenu.SetActive(false);
        VisitLoanShark.SetActive(false);
        LoanShark.SetActive(false);
        _player = new Player(StartingCash, StartingDebt);
        _br = new City("Bronx", Instantiate(prefab, new Vector2(-5, 2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _gh = new City("Ghetto", Instantiate(prefab, new Vector2(0, 2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _ce = new City("Central Park", Instantiate(prefab, new Vector2(5, 2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _ma = new City("Manhattan", Instantiate(prefab, new Vector2(-5, -2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _co = new City("Coney Island", Instantiate(prefab, new Vector2(0, -2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _b = new City("Brooklyn", Instantiate(prefab, new Vector2(5, -2), Quaternion.identity), RandValue(_cRange), RandValue(_hRange), RandValue(_aRange), RandValue(_wRange), RandValue(_sRange), RandValue(_lRange));
        _cityList.Add(_br); _cityList.Add(_gh); _cityList.Add(_ce); _cityList.Add(_ma); _cityList.Add(_co); _cityList.Add(_b);
        BuySell.Add(BuyMenu); BuySell.Add(SellMenu);
        BuyInput.Add(BuyCocaine); BuyInput.Add(BuyHeroin); BuyInput.Add(BuyAcid); BuyInput.Add(BuyWeed); BuyInput.Add(BuySpeed); BuyInput.Add(BuyLudes);
        SellInput.Add(SellCocaine); SellInput.Add(SellHeroin); SellInput.Add(SellAcid); SellInput.Add(SellWeed); SellInput.Add(SellSpeed); SellInput.Add(SellLudes);
        _loanShark.Add(Repay); _loanShark.Add(Borrow);
        SetValidationInt(BuyInput);
        SetValidationInt(SellInput);
        SetValidationInt(_loanShark);
    }
    private void Update()
    {
        if (_currentDay != 30)
        {
            if (onTrigger)
            {
                if (lastCity != triggerName)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovemement>().canMove = false;
                    UI.SetActive(false);
                    CityUI.SetActive(true);
                    RefreshValues(triggerName);
                    lastCity = triggerName;
                }
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
                FinalMoney.text = $"In total you earned: {_player.cash}" + "\n \n Do you want to play again?";
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
                prices[0] = element.cocaine;
                prices[1] = element.heroin;
                prices[2] = element.acid;
                prices[3] = element.weed;
                prices[4] = element.speed;
                prices[5] = element.ludes;
            }
            if (name.Contains(_br.cityName) && element.cityName.Contains(name))
            {
                LoanSharkActive();
            }
        }
        onTrigger = false;
    }
    void SetValidationInt(List<TMP_InputField> input)
    {
        foreach (var element in input)
        {
            element.characterValidation = TMP_InputField.CharacterValidation.Integer;
        }
    }
    void LoanSharkActive()
    {
        VisitLoanShark.SetActive(true);
    }
    public void LoanSharkOpen()
    {
        VisitLoanShark.SetActive(false);
        LoanShark.SetActive(true);
        CurrentDebt.text = $"Current debt: {_player.debt}";
    }
    public void LoanSharkFinish()
    {
        SetEmptyToZero(_loanShark);
        if (int.Parse(_loanShark[0].text) < 0 || int.Parse(_loanShark[1].text) < 0)
        {
            MessageBox.Show("You can't repay or borrow 0!", "Warning!", MessageBoxButtons.OK);
        }
        else
        {
            if (_player.debt - int.Parse(_loanShark[0].text) < 0)
            {
                _player.cash -= _player.debt;
                _player.debt = 0;
                _player.cash += int.Parse(_loanShark[1].text);
                _player.debt += int.Parse(_loanShark[1].text);
                invText.text = _player.DisplayInventory();
                LoanShark.SetActive(false);
            }
            else if (int.Parse(_loanShark[0].text) > _player.cash)
            {
                MessageBox.Show("You don't have enough cash!", "Warning!", MessageBoxButtons.OK);
            }
            else
            {
                _player.cash -= int.Parse(_loanShark[0].text);
                _player.debt -= int.Parse(_loanShark[0].text);
                _player.cash += int.Parse(_loanShark[1].text);
                _player.debt += int.Parse(_loanShark[1].text);
                invText.text = _player.DisplayInventory();
                LoanShark.SetActive(false);
            }
            
        }
    }

    #region MenuFunctions
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
        UnityEngine.Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    #endregion
    
    #region BuySellFunctions
    public void OpenBuy()
    {
        CityUI.SetActive(false);
        BuyMenu.SetActive(true);
        BuypricesText.text = shopText.text.TrimStart(BuySellJet) + $"\n \n Cash = {_player.cash}";
    }
    public void OpenSell()
    {
        CityUI.SetActive(false);
        SellMenu.SetActive(true);
        SellpricesText.text = shopText.text.TrimStart(BuySellJet);
        invAmountText.text = $"\n {_player.inv.cocaineAmount}" +
                        $"\n {_player.inv.heroinAmount}" +
                        $"\n {_player.inv.acidAmount}" +
                        $"\n {_player.inv.weedAmount}" +
                        $"\n {_player.inv.speedAmount}" +
                        $"\n {_player.inv.ludesAmount}";
    }
    public void Buy()
    {
        SetEmptyToZero(BuyInput);
        if (_player.cash - CalculateInput(BuyInput) < 0)
        {
            MessageBox.Show("You don't have enough money for those drugs!", "Warning!", MessageBoxButtons.OK);
            ResetInput(BuyInput);
        }
        else
        {
            _player.cash -= CalculateInput(BuyInput);
            _player.inv.cocaineAmount += int.Parse(BuyCocaine.text);
            _player.inv.heroinAmount += int.Parse(BuyHeroin.text);
            _player.inv.acidAmount += int.Parse(BuyAcid.text);
            _player.inv.weedAmount += int.Parse(BuyWeed.text);
            _player.inv.speedAmount += int.Parse(BuySpeed.text);
            _player.inv.ludesAmount += int.Parse(BuyLudes.text);
            ResetInput(BuyInput);
            Return();
        }
    }
    public void Sell()
    {
        SetEmptyToZero(SellInput);
        if (int.Parse(SellCocaine.text) > _player.inv.cocaineAmount ||
            int.Parse(SellHeroin.text) > _player.inv.heroinAmount ||
            int.Parse(SellAcid.text) > _player.inv.acidAmount ||
            int.Parse(SellWeed.text) > _player.inv.weedAmount || 
            int.Parse(SellSpeed.text) > _player.inv.speedAmount ||
            int.Parse(SellLudes.text) > _player.inv.ludesAmount)
        {
            MessageBox.Show("You don't have enough drugs for that sale!", "Warning!", MessageBoxButtons.OK);
            ResetInput(SellInput);
        }
        else
        {
            _player.cash += CalculateInput(SellInput);
            _player.inv.cocaineAmount -= int.Parse(SellCocaine.text);
            _player.inv.heroinAmount -= int.Parse(SellHeroin.text);
            _player.inv.acidAmount -= int.Parse(SellAcid.text);
            _player.inv.weedAmount -= int.Parse(SellWeed.text);
            _player.inv.speedAmount -= int.Parse(SellSpeed.text);
            _player.inv.ludesAmount -= int.Parse(SellLudes.text);
            ResetInput(SellInput);
            Return();
        }
    }
    public void Return()
    {
        foreach (GameObject element in BuySell)
        {
            element.SetActive(false);
        }
        CityUI.SetActive(true);
        invText.text = _player.DisplayInventory();
    }
    void ResetInput(List<TMP_InputField> Input)
    {
        foreach (var element in Input)
        {
            element.text = "0";
        }
    }
    void SetEmptyToZero(List<TMP_InputField> Input)
    {
        foreach (var element in Input)
        {
            if (element.text == "")
            {
                element.text = "0";
            }
        }
    }
    int CalculateInput(List<TMP_InputField> Input)
    {
        int output = 0;
        for (int i = 0; i < 6; i++)
        {
            output += int.Parse(Input[i].text) * prices[i];
        }
        return output;
    }
    #endregion
    
    #endregion
}

#region Classes
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
        return GameManager.BuySellJet +
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
    public Player(int startCash, int startDebt)
    {
        cash = startCash;
        debt = startDebt;
    }
    public string DisplayInventory()
    {
        return GameManager.ShowInventory +
                       $"\n Cocaine = {inv.cocaineAmount}" +
                       $"\n Heroin = {inv.heroinAmount}" +
                       $"\n Acid = {inv.acidAmount}" +
                       $"\n Weed = {inv.weedAmount}" +
                       $"\n Speed = {inv.speedAmount}" +
                       $"\n Ludes = {inv.ludesAmount}" +
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
    public Inventory(int space = 100, int c = 0, int h = 0, int a = 0, int w = 0, int s = 0, int l = 0)
    {
        invSpace = space;
        cocaineAmount = c;
        heroinAmount = h;
        acidAmount = a;
        weedAmount = w;
        speedAmount = s;
        ludesAmount = l;
    }
}
#endregion
