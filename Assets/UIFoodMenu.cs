using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIFoodMenu : MonoBehaviour {

    public GameObject Menu;
    public GameObject PlaceOrder;

    public GameObject OrderTimer;

    public Text HourDisplay;
    public Text MinuteDisplay;

    private int Hour;
    private int Minture;

    void Start () {

        Menu.SetActive(false);
        PlaceOrder.SetActive(false);
        OrderTimer.SetActive(false);

        BackToMenu();

    }

    private void Update()
    {
        HourDisplay.text = Hour.ToString("00");
        MinuteDisplay.text = Minture.ToString("00");
    }

    public void PickFood()
    {
        Menu.SetActive(false);
        PlaceOrder.SetActive(true);
        OrderTimer.SetActive(false);
    }

    public void BackToMenu()
    {
        Menu.SetActive(true);
        PlaceOrder.SetActive(false);
    }

    public void ShowOrderTimer()
    {
        Hour = DateTime.Now.Hour;
        Minture = RoundUp(DateTime.Now, TimeSpan.FromMinutes(15)).Minute;
        OrderTimer.SetActive(true);
    }

    public void ModifyHour(int mod)
    {
        if (mod > 0)
        {
            Hour++;
        }
        else
            Hour--;
    }

    public void ModifyMinture(int mod)
    {
        switch (Minture)
        {
            case 0:
                if (mod > 0)
                    Minture = 15;
                else
                {
                    Minture = 45;
                    Hour--;
                }
                break;
            case 15:
                if (mod > 0)
                    Minture = 30;
                else
                    Minture = 0;
                break;
            case 30:
                if (mod > 0)
                    Minture = 45;
                else
                    Minture = 15;
                break;
            case 45:
                if (mod > 0)
                {
                    Hour++;
                    Minture = 0;
                }
                else
                    Minture = 30;
                break;
        }
    }

    public void ComfirmPlaceOrder()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }


    private DateTime RoundUp(DateTime dt, TimeSpan d)
    {
        return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
    }
}
