using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamekultQuest : MonoBehaviour
{
    public Transform canvas;
    public ThirdPersonMovement player;
    public CursorHide cursor;

    public GameObject articlePrefab;

    private GameObject articleClone;

    public void ShowArticle()
    {
        //cursor.enabled = false;
        articleClone = Instantiate(articlePrefab, canvas);
        player.currentSpeed = 0;
    }

    public void ArticleDown()
    {
        //cursor.enabled = true;
        Destroy(articleClone);
        player.currentSpeed = player.speed;
    }
}