using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spike : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.position = PlayerController.instance.spawnCord;
    }

    public void Active()
    {
        UIManager.instance.CountLevel.gameObject.SetActive(false);
    }
}
