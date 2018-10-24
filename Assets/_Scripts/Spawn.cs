using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public static void UpdatePointSpawn(GameObject gameObject)//обновление координат
    {
        PlayerController.instance.spawnCord = gameObject.transform.position;
    }
}
