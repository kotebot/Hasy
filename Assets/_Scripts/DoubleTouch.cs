using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTouch : MonoBehaviour {

    public GameObject activeObject;

    private bool Click=false;

    public void DoubleTouchActive()
    {
        if (Click)
            activeObject.SetActive(true);
        Click = true;
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        Click = false;
    }
}
