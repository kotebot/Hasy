using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveResult : MonoBehaviour {



	public static void SaveRes()
    {
        if(!PlayerPrefs.HasKey(GameManager.instance.Level.ToString()))
        {
            PlayerPrefs.SetString(GameManager.instance.Level.ToString(), Timer.time.ToString());
            GameManager.instance.CompliteLevel = true;
        }
        if(PlayerPrefs.HasKey(GameManager.instance.Level.ToString())&& ResetStopwath.ResStopwath)
        {
            PlayerPrefs.SetString(GameManager.instance.Level.ToString(), Timer.time.ToString());
            GameManager.instance.CompliteLevel = true;
            ResetStopwath.ResStopwath = false;
        }
    }

    public static void LoadRes()
    {

        if (PlayerPrefs.HasKey(GameManager.instance.Level.ToString()))
        {
            if(!ResetStopwath.ResStopwath)
            { 
                GameManager.instance.CompliteLevel = true;
                UIManager.instance.Stopwatch.fontSize = 144;
                UIManager.instance.Stopwatch.text = PlayerPrefs.GetString(GameManager.instance.Level.ToString());
            }
        }
    }
}
