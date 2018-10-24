using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveResult : MonoBehaviour {



	public static void SaveRes()//сохранение
    {
        if(!PlayerPrefs.HasKey(GameManager.instance.Level.ToString()))//если такого уровня не существует
        {
            PlayerPrefs.SetString(GameManager.instance.Level.ToString(), Timer.time.ToString());//сохраняем уровень и значение таймера
            GameManager.instance.CompliteLevel = true;//уровень пройден
        }
        if(PlayerPrefs.HasKey(GameManager.instance.Level.ToString())&& ResetStopwath.ResStopwath)//тоже самое, при этом сбивая таймер
        {
            PlayerPrefs.SetString(GameManager.instance.Level.ToString(), Timer.time.ToString());
            GameManager.instance.CompliteLevel = true;
            ResetStopwath.ResStopwath = false;
        }
    }

    public static void LoadRes()//загрузка
    {

        if (PlayerPrefs.HasKey(GameManager.instance.Level.ToString()))//если существует сохранение для данного уровня
        {
            if(!ResetStopwath.ResStopwath)//и мы не сбиваем таймер
            { 
                GameManager.instance.CompliteLevel = true;//уровень пройден
                UIManager.instance.Stopwatch.fontSize = 144;//размер таймера больше
                UIManager.instance.Stopwatch.text = PlayerPrefs.GetString(GameManager.instance.Level.ToString());//значение таймера
            }
        }
    }
}
