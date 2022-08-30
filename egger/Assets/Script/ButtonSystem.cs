using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class ButtonSystem : MonoBehaviour
{
    public Image BackGroundImage;
    public Text GameOverText;
    public Button RestartButton;
    public Button TitleButton;
    public TMP_InputField inputField;
    public AudioSource ButtonSE;

    float tmp;
    public static string UserName;
    int flag;

    public void OnClick()
    {
        ButtonSE.Play(0);
    }

    private void Start()
    {
        
        flag = 0;
    }

    public void Title()
    {
        SceneManager.LoadScene("1.Title");
    }

    public void GetUserName()
    {
        UserName = inputField.text;
        if (UserName == "") UserName = "No Name";
        if(inputField.text.Length > 7)
        {
            UserName = inputField.text.Substring(0, 7);
        }
        inputField.text = "";
        flag = 1;
    }

    public void GameStart()
    {
        if (flag == 0)
        {
            GetUserName();
            SceneManager.LoadScene("2.Rule");
        }
        else
        {
            SceneManager.LoadScene("3.Play");
        }
    }


    public void Restart()
    {
        BackGroundImage.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        TitleButton.gameObject.SetActive(false);

        flag = 1;
        GameStart();
    }

}
