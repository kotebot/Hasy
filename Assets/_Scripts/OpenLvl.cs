using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenLvl : MonoBehaviour {

    public GameObject @this;
    private InputField variable;

    private void Start()
    {
        variable = GetComponent<InputField>();     
    }

    public void OpenLevel()
    {
        if(PlayerPrefs.HasKey(variable.text))
            SceneManager.LoadScene(int.Parse(variable.text));
    }

    public void Close()
    {
        @this.SetActive(false);
    }
}
