using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using System;
public class TimerController : MonoBehaviour
{
    public float timeleft = 10.0f;
    public TextMeshProUGUI warningText;

    public bool isday = true;
    private int timeleftint;

    public bool gameover = false;
    public bool win = false; 

    public GameObject sunlight;
    

    // Start is called before the first frame update
    void Start()
    {
        timeleftint = (int)Math.Round(timeleft);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover){
            timeleft -= Time.deltaTime;
            timeleftint = (int)Math.Round(timeleft);
            if (timeleft < 0) {
                timeleft = 10; 
                
                isday = !isday; 
            }

            if (isday) {
                warningText.text = "Warning: night in " + timeleftint.ToString() + " seconds:";
                RenderSettings.ambientIntensity = 1.0f;
                sunlight.SetActive(true);
            } else {
                warningText.text = "Daytime in " + timeleftint.ToString() + " seconds:";
                RenderSettings.ambientIntensity = 0.01f;
                sunlight.SetActive(false);
            }
        } else {
            if (win){
                RenderSettings.ambientIntensity = 1.0f;
                sunlight.SetActive(true);
            }
            else{
                RenderSettings.ambientIntensity = 0.01f;
                sunlight.SetActive(false);
            }
        }

    }
}
