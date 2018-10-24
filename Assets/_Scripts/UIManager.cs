using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShermanLibr;
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public TextMeshProUGUI Stopwatch;//ссылка  на протекст для секундомера
    public TextMeshProUGUI CountLevel;//счетчик уровня
    public TextMeshProUGUI FinishText;//финал текст
    public FixedJoystick joystick;//джойстик
    public GameObject[] AndroidUI;//ui для анлроид
    public string[] WinString;//текст для победы

    private void Awake()
    {
        instance = this;
        if (Platform.Android)
        {
            for (int i = 0; i < AndroidUI.Length; i++)
                AndroidUI[i].SetActive(true);
        }

    }

    private void Start()
    {
        CountLevel.text = GameManager.instance.Level.ToString();//выводим номер лвл на экран


    }

    void Update () {
        if (!GameManager.instance.CompliteLevel)//если уровень не пройден запускаем таймер
            Stopwatch.text = Timer.time.ToString();
	}
    
    public void Fin()//финалочка
    {
        FinishText.gameObject.SetActive(true);
        FinishText.text = WinString[Random.Range(0, WinString.Length)];
    }

    public void NextLevel()//след уровень
    {
        try
        {
            if(GameManager.instance.CompliteLevel)   
                SceneManager.LoadScene(GameManager.instance.Level+1);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Нету след. уровня");
            throw;
        }
    }

    public void PrewLevel()//предыдущий лвл
    {
        try
        {
            if (GameManager.instance.Level>0)
                SceneManager.LoadScene(GameManager.instance.Level-1);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Нету пред. уровня");
            throw;
        }
    }


}
