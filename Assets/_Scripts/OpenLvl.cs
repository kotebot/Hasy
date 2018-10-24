using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenLvl : MonoBehaviour {

    [SerializeField]
    private GameObject @this;//ссылка родителський обьект свой объект
    private InputField variable;//поле для ввода

    private void Start()
    {
        variable = GetComponent<InputField>();     
    }

    public void OpenLevel()//открытие лвл
    {
        if(PlayerPrefs.HasKey(variable.text))//если такой уровень сохранен
            SceneManager.LoadScene(int.Parse(variable.text));//загрузка сцены
    }

    public void Close()//просто закрытие
    {
        @this.SetActive(false);
    }
}
