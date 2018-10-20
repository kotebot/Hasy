using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    public PlayerController Pc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pc = FindObjectOfType<PlayerController>();
        if(collision.tag=="Player")
        {
            if(!GameManager.instance.CompliteLevel)
            { 
                Timer.time.StopwatchStop();
                SaveResult.SaveRes();
            }
            UIManager.instance.Fin();
            Pc.enabled = false;
            
        }
        
        
    }
}
