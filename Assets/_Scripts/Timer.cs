using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public static ShermanLibr.Time time;

    public void Start()
    {
        time = new ShermanLibr.Time();//по факту изаю библиотеку
    }

    public void Update()
    {
        if(!GameManager.instance.CompliteLevel)
            time.StopwatchPlay();
        if(ResetStopwath.ResStopwath)
            time.StopwatchPlay();
    }
}


