using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotLever : MonoBehaviour {

    public bool gravity;
    private bool Move = false;
    private Animation anim;
    public bool Open=false;

    private void Start()
    {
        anim=GetComponent<Animation>();
    }

    public void Rotate()
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
