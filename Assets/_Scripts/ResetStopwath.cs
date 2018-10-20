using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetStopwath : MonoBehaviour {

    public GameObject @this;
    public static bool ResStopwath=false;
    private const string IDResetStopWath= "resetstapwath";
    private bool flag;

    public void Update()
    {
        if (ShermanLibr.AD.isPlayed)
            Time.timeScale = 0;
        else Time.timeScale = 1;
        Debug.Log(Time.timeScale);
    }

    public void Yes()
    {
        ShermanLibr.AD.ShowAd(IDResetStopWath);
        ResStopwath = true;
        SceneManager.LoadScene(GameManager.instance.Level);


    }

    public void No()
    {
        @this.SetActive(false);
    }
}
