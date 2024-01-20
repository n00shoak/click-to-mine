using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class refinementManager : MonoBehaviour
{
    [SerializeField] mineBar mine;
    public sellsManager money;
    public Slider[] sliders;
    public TextMeshProUGUI[] text;

    public int[] targets;

    public int pureMetal;
    public int Ingots;

    public int[] Yields;

    public int[] baseCost;
    public TextMeshProUGUI[] upgradesFB;
    public int[] levels; 

    private void Update()
    {
        //set max
        sliders[0].maxValue = targets[0]; 
        sliders[1].maxValue = targets[1]; 

        //set current value
        sliders[0].value = mine.oreValue;
        sliders[1].value = pureMetal;

        //traduction
        if(mine.oreValue >= targets[0])
        {
            pureMetal += Yields[0];
            mine.oreValue = 0;
        }

        if(pureMetal >= targets[1])
        {
            Ingots += Yields[0];
            pureMetal = 0;
        }

        //feedBack
        text[0].text = " raw ore = " + mine.oreValue.ToString() + " / "  + " pure ore = " + pureMetal.ToString();
        text[1].text = " pure ore = " + pureMetal.ToString() + " / " + " ingots = " + Ingots.ToString();

        text[2].text = targets[0].ToString() + " => " + Yields[0].ToString();
        text[3].text = targets[1].ToString() + " => " + Yields[1].ToString();
    }

    public void upgrade(int id)
    {
        int wich = (id * 3);
        Debug.Log(wich + "  " + id);
        if (money.money >= baseCost[id])
        {
            money.money -= baseCost[id];
            baseCost[id] = +Mathf.RoundToInt(baseCost[id] * 1.7f);
            levels[id]++;
            // feed back :
            upgradesFB[wich].text = "LV "+ levels[id].ToString();
            upgradesFB[wich + 1].text = "Cost : " + baseCost[id].ToString();

            if(id == 0 || id == 1)
            {
                Yields[id]++;
                targets[id] += 5 * levels[id] + 1;
                upgradesFB[wich + 2].text = "every conversion produce " + Yields[id] + " recources";
            }
            else 
            {
                if(targets[id - 2] > 1)
                    targets[id - 2] -= 3;
                else { targets[id - 2] = 1; }
            }
        }
    }
}
