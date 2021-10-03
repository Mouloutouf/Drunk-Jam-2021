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

    [Header("FX")]
    public GameObject star_FX;
    public GameObject type_FX;

    private void Start()
    {
        quest = FindObjectOfType<GamekultQuest>();
    }

    private void Update()
    {
        if (starsCompletion >= 5)
        {
            if (Input.anyKeyDown)
            {
                TypeFX();

                reviewText.text = reviewText.text + articleWords[articleCompletion];
                articleCompletion++;

                if (articleCompletion >= articleCompletionMax)
                    quest.ArticleDown();
            }
        }
    }

    public void StarClicked()
    {
        starsCompletion++;

        if (starsCompletion <= 5 )
        {
            stars[starsCompletion-1].color = starsOkColor;
            stars[starsCompletion - 1].transform.localScale *= 1.5f;
            StarFX();

        }
    }


    /////FX
    ///
    void StarFX()
    {
        if(star_FX != null) Instantiate(star_FX);
    }
    void TypeFX()
    {
        if (type_FX != null) Instantiate(type_FX);
    }
}