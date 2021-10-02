using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Container : MonoBehaviour
{
    public float timer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeBeforeDestruction());
    }


    IEnumerator TimeBeforeDestruction()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
