using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sellsManager : MonoBehaviour
{
    public refinementManager refinement;
    public TextMeshProUGUI[] texts;
    public int money;

    public void sells()
    {
        money += refinement.Ingots*10;
        refinement.Ingots = 0;
    }

    private void Update()
    {
        for(int i  = 0; i < texts.Length; i++)
        {
            texts[i].text = money.ToString();
        }
    }
}
