using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    public PlayerController Pc;
    public float sher;
    private void OnTriggerEnter2D(Collider2D collision)//если заходишь в тригер
    {
        Pc = FindObjectOfType<PlayerController>();//находим класс PlayerConoller в сцене
        if (collision.tag=="Player")//если тэг в объекта который зашел в триггер Player
        {
            if(!GameManager.instance.CompliteLevel)//если уровень не пройден
            { 
                Timer.time.StopwatchStop();//остановка секундомера
                SaveResult.SaveRes();//сохран результатов
            }
            UIManager.instance.Fin();//финал
            Pc.enabled = false;//выключаем контроллер

        }
        
        
    }
}
