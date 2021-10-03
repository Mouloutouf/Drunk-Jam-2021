using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArticleBehaviour : MonoBehaviour
{
    private GamekultQuest quest;
    public TextMeshProUGUI reviewText;
    public Image[] stars;
    public int articleCompletionMax;
    public string[] articleWords;

    public Color starsOkColor;

    public int starsCompletion;
    public int articleCompletion;

    private void Start()
    {
        quest = FindObjectOfType<GamekultQuest>();
    }

    private void Update()
    {
        if (starsCompletion == 4)
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("yeet");

                reviewText.text = reviewText.text + articleWords[articleCompletion];
                articleCompletion++;

                if (articleCompletion >= articleCompletionMax)
                    quest.ArticleDown();
            }
        }
    }

    public void StarClicked()
    {
        stars[starsCompletion].color = starsOkColor;

        if (starsCompletion < 4)
            starsCompletion++;
    }
}