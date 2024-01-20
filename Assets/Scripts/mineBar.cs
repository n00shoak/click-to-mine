using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mineBar : MonoBehaviour
{
    public Slider FeedBack;
    public sellsManager money;
    public TextMeshProUGUI score;
    public TextMeshProUGUI[] YieldLV;
    public TextMeshProUGUI[] aspeedLV;
    public TextMeshProUGUI[] manualPowerLV;
    public Button[] Upgrades;
    public mineManager mineManager;
    public int oreValue;
    public int progress;
    public int minePower; //mine boost on click
    public int yield;
    public int ID;

    public float YieldPrice;
    public float aspeedPrice;
    public float manualPowerPrice;

    public int AutoSpeedLV;
    public int manualMineLV;

    public AudioSource sound;

    private void Start()
    {
        FeedBack.value = oreValue;
    }

    private void Update()
    {
        //check if the player can buy an upgrade
        if (money.money >= YieldPrice) 
        {
            Upgrades[0].interactable = true;
        }
        else { Upgrades[0].interactable = false; }

        if (money.money >= aspeedPrice)
        {
            Upgrades[1].interactable = true;
        }
        else { Upgrades[1].interactable = false; }

        if (money.money >= manualPowerPrice)
        {
            Upgrades[2].interactable = true;
        }
        else { Upgrades[2].interactable = false; }
    }

    //when player click on mine button
    public void Mine()
    {
        if(minePower > 1000)
        {
            oreValue += (minePower / 100) * yield;
            progress += minePower % 100;
            score.text = oreValue.ToString();
        }
        else
        {
            progress += minePower;
        }
    }

    //progress bar of mining
    public void ProgressBar()
    {
        progress++;
        FeedBack.value = progress;
        if (progress >= 100)
        {
            oreValue += yield;
            sound.Play();
            score.text = oreValue.ToString();
            progress = 0;
        }
    }

    public void yieldUp()
    {
        yield++;
        YieldLV[0].text = "LV " + (yield - 1).ToString();
        YieldLV[1].text = " Effect : +" + (yield - 1).ToString() + " bonus yield";
        money.money -= Mathf.RoundToInt(YieldPrice);
        YieldPrice += Mathf.Round(YieldPrice * 1.25f);
        YieldLV[2].text = " Cost : " + YieldPrice.ToString();
    }

    public void AutoSpeedUp()
    {
        AutoSpeedLV++;
        aspeedLV[0].text = "LV " + AutoSpeedLV;
        aspeedLV[1].text = " Effect : speed bonus at " + (mineManager.updateSpeed[ID]).ToString();
        money.money -= Mathf.RoundToInt(aspeedPrice);
        aspeedPrice += Mathf.Round(aspeedPrice * 0.5f);
        aspeedLV[2].text = " Cost : " + aspeedPrice.ToString();

    }

    public void ClickUp()
    {
        manualMineLV++;
        minePower += Mathf.RoundToInt(minePower * 0.5f);
        manualPowerLV[0].text = "LV " + (manualMineLV).ToString();
        manualPowerLV[1].text = " Effect : +" + (minePower).ToString() + " mining progress on click ";
        money.money -= Mathf.RoundToInt(manualPowerPrice);
        manualPowerPrice += Mathf.Round(manualPowerPrice * 0.9f);
        manualPowerLV[2].text = " Cost : " + manualPowerPrice.ToString();
    }
}

