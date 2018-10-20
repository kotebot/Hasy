using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour {

    public GameObject DesiredLevel;
    public GameObject ResetLvlVideo;
    private FixedJoystick joystick;

    private void Start()
    {
        joystick = GetComponent<FixedJoystick>();
    }

    void Update () {
        if (joystick.Horizontal >= 0.98)
            UIManager.instance.NextLevel();
        else if (joystick.Horizontal <=-0.98)
            UIManager.instance.PrewLevel();
        else if (joystick.Vertical >= 0.98)
            DesiredLevel.SetActive(true);
        else if (joystick.Vertical <= -0.98)
            ResetLvlVideo.SetActive(true);
    }
}
