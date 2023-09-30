using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class clock : MonoBehaviour
{
    public Transform minutes;
    public Transform secs;
    public TextMeshProUGUI timeText;
    //public float deg = 90f;

    private const float DAY_TOOK_MINUTES = 60f * 60f; // 60 mp = 1 nap
    private float in_game_day;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        float dayDegree = 360f;
        float minPerHour = 60f;
        float secsPerMin = 60f;

        //float rotationPerDay = 360f;
        in_game_day += Time.deltaTime / DAY_TOOK_MINUTES; //h�nyszor p�rd�lt �t a mutat� az �r�n (napok sz�ma, nem resetel�dik)

        float in_game_day_norm = in_game_day % 1f; //0-1ig 0 a d�l 0.9999 d�l el�tti p�r tized (resetel�dik minden k�r ut�n)

        minutes.eulerAngles = new Vector3(0, 0, -in_game_day_norm * dayDegree); //minutes 24x gyorsabban p�r�g
        secs.eulerAngles = new Vector3(0, 0, -in_game_day_norm * dayDegree * minPerHour);

        //minutes.eulerAngles = new Vector3(0, 0, -Time.realtimeSinceStartup * 90f); //1mp = 90 fok



        //Debug.Log("in_game_day:"+ in_game_day+ "in_game_day_norm:" + in_game_day_norm);




        ////hand.eulerAngles = new Vector3(0, 0, -Time.realtimeSinceStartup * deg);
        //hours.eulerAngles = new Vector3(0, 0, -in_game_day_norm * rotationPerDay);





        string minutesString = Mathf.Floor((in_game_day_norm * minPerHour)).ToString("00");
        string secondsString = Mathf.Floor(((in_game_day_norm * minPerHour) % 1f) * secsPerMin).ToString("00"); //milseconds

        timeText.text = minutesString + " : " + secondsString;

    }
}
