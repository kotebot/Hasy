using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour {

    public Subject[] subject;

    public bool gravity;
    public bool pointSpawn=false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gravity)
            Gravity.UpdateGravity();
        for(int i =0; i<subject.Length;i++)
        {
            if (!subject[i].subject.Open)
                subject[i].Anim.Play(subject[i].Action);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gravity)
            Gravity.UpdateGravity();
        for (int i = 0; i < subject.Length; i++)
        {
            if (subject[i].subject.Open&&!subject[i].Opened)
                subject[i].Anim.Play(subject[i].Action + "Back");
            if(subject[i].Opened) subject[i].Anim.Play(subject[i].Action + "Back");
        }
        
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.tag=="Player"|| collision.collider.tag == "Box")
        { 
            GetComponentInParent<PivotLever>().Rotate();

            if (pointSpawn)
                Spawn.UpdatePointSpawn(collision.gameObject);

            for (int i = 0; i < subject.Length; i++)
            {
                if (subject[i].Action != "Jump")
                {
                    if (subject[i].subject.Open && subject[i].Action != "Transparence")
                        subject[i].Anim.Play(subject[i].Action + "Back");
                    else
                        subject[i].Anim.Play(subject[i].Action);
                }
                else
                {
                    subject[i].subject.activeJump = true;
                }
            }
        }
    }
       
}


[System.Serializable]
public class Subject
{
    public TransformObject subject;
    public Animation Anim;
    public string Action;
    public bool Opened;
}