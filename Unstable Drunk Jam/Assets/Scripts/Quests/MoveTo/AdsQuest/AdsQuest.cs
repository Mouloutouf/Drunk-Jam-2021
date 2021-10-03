using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsQuest : MonoBehaviour
{
    //public CursorHide cursor;

    public Transform canvas;

    public float[] timeMinMax;
    public float[] spawnMinMax;
    public GameObject[] ads;

    private float timeToWait;
    private GameObject adClone;
    private List<GameObject> currentAds = new List<GameObject>();

    public void ShowFirstAd()
    {
        //cursor.enabled = false;
        ShowNewAd();
    }

    public void ShowNewAd()
    {
        timeToWait = Random.Range(timeMinMax[0], timeMinMax[1]);
        StartCoroutine(AdTimer());
    }

    public void StopAds()
    {
        //cursor.enabled = true;
        foreach (var ad in currentAds)
        {
            Destroy(ad);
        }
        currentAds.Clear();
        StopAllCoroutines(); //ptet problématique
    }

    IEnumerator AdTimer()
    {
        yield return new WaitForSeconds(timeToWait);
        adClone = Instantiate(ads[Random.Range(0, ads.Length)], canvas);
        adClone.GetComponent<AdBehaviour>().OpenAdFX();

        adClone.transform.position = new Vector2(Random.Range(spawnMinMax[0], spawnMinMax[1]), Random.Range(spawnMinMax[2], spawnMinMax[3]));
        currentAds.Add(adClone);
        ShowNewAd();
    }
}