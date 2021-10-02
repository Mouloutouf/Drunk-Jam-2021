using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdBehaviour : MonoBehaviour
{
    public void CloseAd()
    {
        Destroy(gameObject);
    }
}