using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShermanLibr;
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public TextMeshProUGUI Stopwatch;
    public TextMeshProUGUI CountLevel;
    public TextMeshProUGUI FinishText;
    public FixedJoystick joystick;
    public GameObject[] AndroidUI;
    public string[] WinString;

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
        CountLevel.text = GameManager.instance.Level.ToString();
        

    }

    void Update () {
        if (!GameManager.instance.CompliteLevel)
            Stopwatch.text = Timer.time.ToString();
	}
    
    public void Fin()
    {
        FinishText.gameObject.SetActive(true);
        FinishText.text = WinString[Random.Range(0, WinString.Length)];
    }

    public void NextLevel()
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

    public void PrewLevel()
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
