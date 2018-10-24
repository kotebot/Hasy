using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShermanLibr;

public class GameManager : MonoBehaviour {

    public static GameManager instance;//синглтон

    public bool CompliteLevel;//пройден ли уровень
    public int Level;//номер уровня
    public GameObject player;//ссылка на игрока
    public Animation[] rainSpike;//анимация "дождя"
    private const string GameID = "2753079";//id игры в юнити ads

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        Platform.ReturnPlatform();//узнаем платформу
        AD.Inicial(GameID);//иницализируем игру для рекламы
        instance = this;//ссылка на себя

    }

    void Start () {
        SaveResult.LoadRes();//загружаем результаты
        StartCoroutine(playAnim());//запускаем дождик
    }

    public void Restart()//рестарт
    {
        player.transform.position = PlayerController.instance.spawnCord;
    }
	
    private IEnumerator playAnim()//анимация дождика
    {
        while (true)
        { 
            for (int i=0; i < rainSpike.Length;i++)
            {
                rainSpike[i].Play();//запуск анимации                
                yield return new WaitForSeconds(0.15f);//ждем 0.15сек

            }
            yield return new WaitForSeconds(0.7f);

            for (int i = rainSpike.Length-1; i >= 0; i--)
            {
                rainSpike[i].Play();
                yield return new WaitForSeconds(0.15f);
            }
            yield return new WaitForSeconds(0.7f);
        }
    }

}
