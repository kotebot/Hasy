using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    
    public static AudioManager instance;//ссылка на себя

    public AudioSource[] background;//массив фоновой мyзыки

    public AudioSource jump;

    private void Start()
    {
        instance = this;//ссылка не себя
        background[Random.Range(0, 2)].Play();//запуск рандомной фоновой песни
    }

}
