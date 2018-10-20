using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShermanLibr;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool CompliteLevel;
    public int Level;
    public GameObject player;
    public Animation[] rainSpike;
    private const string GameID = "2753079";

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        Platform.ReturnPlatform();
        AD.Inicial(GameID);
        instance = this;
        
    }

    void Start () {
        SaveResult.LoadRes();
        StartCoroutine(playAnim());
    }

    public void Restart()
    {
        player.transform.position = PlayerController.instance.spawnCord;
    }
	
    private IEnumerator playAnim()
    {
        while (true)
        { 
            for (int i=0; i < rainSpike.Length;i++)
            {
                rainSpike[i].Play();                
                yield return new WaitForSeconds(0.15f);

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
