using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transition : MonoBehaviour
{
    public Transform camPos;
    public Slider slider;

    public float transitionSpeed;
    bool curtains;

    public void changeScene(int select)
    {
        StartCoroutine(transitionAnim(select));
    }

    public IEnumerator transitionAnim(int selection)
    {
        if(!curtains)
        {
            slider.value += 0.02f;
            yield return new WaitForSeconds(transitionSpeed);
        }
        if (curtains)
        {
            slider.value -= 0.02f;
            yield return new WaitForSeconds(transitionSpeed);
        }

        if(slider.value >= 1f)
        {
            curtains = true;
            camPos.position = new Vector3(selection,camPos.position.y, camPos.position.z);
            yield return new WaitForSeconds(0.5f);
        }
        
        if((slider.value > 0f && curtains) || !curtains) 
        {
            StartCoroutine(transitionAnim(selection));
        }
        else
        {
            curtains = false;
        }
    }
}
