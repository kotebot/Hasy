using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotLever : MonoBehaviour {


    public bool gravity;
    private bool Move = false;//работает ли анимация(изменяем в ивентах в анимации)
    private Animation anim;
    public bool Open=false;//открыт ли

    private void Start()
    {
        anim=GetComponent<Animation>();
    }

    public void Rotate()//поворот
    {
        if (!Move && !Open)
        {
            if (gravity)
                Gravity.UpdateGravity();
            anim.Play("LeverUp");
            Open = true;
        }
        else if (!Move && Open)
        {
            if (gravity)
                Gravity.UpdateGravity();
            anim.Play("LeverDown");
            Open = false;
        }

    }

    public void Play()
    {
        Move = true;
    }

    public void Stop()
    {
        Move = false;
    }
        
}
