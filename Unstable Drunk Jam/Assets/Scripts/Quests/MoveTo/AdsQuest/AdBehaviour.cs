using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdBehaviour : MonoBehaviour
{
    Vector3 baseScale;
    Vector3 minimumScale;
    Vector3 actualScale;
    float time;
    public float scaleSpeed = 1.0f;

    [Header("FX")]
    public GameObject delete_FX;
    public GameObject spawn_FX;

    public void CloseAd()
    {
        if(delete_FX != null) Instantiate(delete_FX);
        Destroy(gameObject);
    }

    public void OpenAdFX()
    {
        if (spawn_FX != null) Instantiate(spawn_FX);
    }

    private void Start()
    {
        baseScale = transform.localScale;
        minimumScale = baseScale / 4;
        transform.localScale = minimumScale;
    }

    private void Update()
    {
        time += Time.deltaTime * scaleSpeed;
        time = Mathf.Clamp(time, 0.0f, 1.0f);

        actualScale = Vector3.Lerp(minimumScale, baseScale, time);
        transform.localScale = actualScale;
    }
}