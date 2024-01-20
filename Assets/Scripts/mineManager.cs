using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineManager : MonoBehaviour
{

    public float[] updateSpeed;
    List<float> updateTimer = new List<float>();
    public mineBar[] scores;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < scores.Length; i++)
        {
            updateTimer.Add(0);
        }
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        for(int i = 0; i < updateSpeed.Length; i++)
        {
            updateTimer[i]++;
            if (updateTimer[i] > ( updateSpeed[i]*2))
            {
                scores[i].ProgressBar();
                updateTimer[i] = 0;
            }
        }
        yield return new WaitForSeconds(0.0001f);
        StartCoroutine(Timer());
    }
}
