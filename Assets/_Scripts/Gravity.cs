using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public static bool InvertGravity=false;

    public static void UpdateGravity()
    {
        Physics2D.gravity = -Physics2D.gravity;
        PlayerController.instance.forceJump = -PlayerController.instance.forceJump;
        InvertGravity = !InvertGravity;
    }
}
