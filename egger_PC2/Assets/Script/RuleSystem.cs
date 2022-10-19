using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RuleSystem : MonoBehaviour
{
    int slidePoint;
    int animePoint;
    int n;
    public GameObject RuleBeginImage;
    public GameObject[] Rule1Image;
    public GameObject[] Rule2Image;
    public GameObject[] RLImage;
    public GameObject RuleEndImage;
    public AudioSource ButtonSE;

    [SerializeField] private GameObject loading;
    [SerializeField] private Slider slider; 

    int flag0 = 0, flag1 = 0, flag2 = 0, flag3 = 0, flag4 = 0;

    public void OnClick()
    {
        ButtonSE.Play(0);
    }

    void Start()
    {
        slidePoint = 0;
        animePoint = 0;
        n = 2;
        False();
    }

    void Update()
    {
        if (slidePoint == -1) // タイトルへ
        {
            SceneManager.LoadScene("1.Title");
        }
        else if(slidePoint == 0) // 開始
        {
            if (flag0 == 0)
            {
                RuleBeginImage.gameObject.SetActive(true);
                flag0 = 1;
                flag1 = 0;
            }
        }
        else if (slidePoint == 1) // ルール概要1
        {
            n = 2;
            if (flag1 == 0)
            {
                ShowNextSlide();
                flag0 = 0;
                flag1 = 1;
                flag2 = 0;
            }
        }
        else if (slidePoint == 2) // ルール概要2
        {
            n = 2;
            if (flag2 == 0)
            {
                ShowNextSlide();
                flag1 = 0;
                flag2 = 1;
                flag3 = 0;
            }
        }
        else if (slidePoint == 3) // 左右
        {
            n = 8;
            if (flag3 == 0)
            {
                ShowNextSlide();
                flag2 = 0;
                flag3 = 1;
                flag4 = 0;
            }
        }
        else if (slidePoint == 4) // 終了
        {
            if (flag4 == 0)
            {
                RuleEndImage.gameObject.SetActive(true);
                flag3 = 0;
                flag4 = 1;
            }
        }
        else if (slidePoint == 5) // プレイ画面へ
        {
            //SceneManager.LoadScene("3.Play");
            loading.SetActive(true);
            StartCoroutine(LoadScene());
        }
    }

    void False() // 全ての画像を非表示
    {
        RuleBeginImage.gameObject.SetActive(false);
        for (int i = 0; i < 2; i++) Rule1Image[i].gameObject.SetActive(false);
        for (int i = 0; i < 2; i++) Rule2Image[i].gameObject.SetActive(false);
        for (int i = 0; i < 8; i++) RLImage[i].gameObject.SetActive(false);
        RuleEndImage.gameObject.SetActive(false);
    }

    void ShowNextSlide()
    {
        False();
        if (slidePoint == 1)
        {
            Rule1Image[animePoint].gameObject.SetActive(true);
        }
        else if (slidePoint == 2)
        {
            Rule2Image[animePoint].gameObject.SetActive(true);
        }
        else if(slidePoint == 3)
        {
            RLImage[animePoint].gameObject.SetActive(true);
        }
        
        animePoint++;
        animePoint %= n;
        Invoke("ShowNextSlide", 0.7f);
    }

    public void BackButton()
    {
        slidePoint--;
        animePoint = 0;
        CancelInvoke();
    }
    public void NextButton()
    {
        slidePoint++;
        animePoint = 0;
        CancelInvoke();
    }
    public void SkipButton()
    {
        CancelInvoke();
        //SceneManager.LoadScene("3.Play");
        loading.SetActive(true);
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        slidePoint++;
        AsyncOperation async = SceneManager.LoadSceneAsync("3.Play");
        while (!async.isDone)
        {
            slider.value = async.progress;
            yield return null;
        }
    }
}
