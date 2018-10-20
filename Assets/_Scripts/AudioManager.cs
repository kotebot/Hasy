using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    public AudioSource[] background;

    public AudioSource jump;

    private void Start()
    {
        instance = this;
        background[Random.Range(0, 2)].Play();
    }

}
