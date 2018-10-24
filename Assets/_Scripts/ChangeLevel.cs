using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour {

    public GameObject DesiredLevel;//выбор лвл
    public GameObject ResetLvlVideo;//перезапуск лвл за просмотр видео
    private FixedJoystick joystick;//джойстик

    private void Start()
    {
        joystick = GetComponent<FixedJoystick>();
    }

    void Update () {
        if (joystick.Horizontal >= 0.98)//вправо-лвл некст
            UIManager.instance.NextLevel();
        else if (joystick.Horizontal <=-0.98)//лево-пред лвл
            UIManager.instance.PrewLevel();
        else if (joystick.Vertical >= 0.98)//вверх - выбор лвл
            DesiredLevel.SetActive(true);
        else if (joystick.Vertical <= -0.98)//вниз-некст лвл за видео
            ResetLvlVideo.SetActive(true);
    }
}
