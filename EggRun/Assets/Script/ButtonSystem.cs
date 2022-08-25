using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonSystem : MonoBehaviour
{
    public Image BackGroundImage;
    public TextMeshProUGUI GameClearText;
    public TextMeshProUGUI GameOverText;
    public Button ResumeButton;
    public Button RestartButton;
    public Button TitleButton;

    public TMP_InputField inputField;

    float tmp;
    public static string UserName;

    int flag;

    private void Start()
    {
        flag = 0;
    }

    public void GetUserName()
    {
        Debug.Log("a:" + flag);
        UserName = inputField.text;
        if (UserName == "") UserName = "No Name";
        inputField.text = "";
        flag = 1;
        Debug.Log("b:" + flag);
    }

    public void GameStart()
    {
        if(flag == 0) GetUserName();
        SceneManager.LoadScene("2.Play");
    }

    public void Pause() {
        BackGroundImage.gameObject.SetActive(true);
        ResumeButton.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        TitleButton.gameObject.SetActive(true);

        tmp = PlayerMove.speed;
        PlayerMove.speed = 0;
    }

    public void Title()
    {
        flag = 0;
        SceneManager.LoadScene("1.Title");
    }

    public void Resume()
    {
        BackGroundImage.gameObject.SetActive(false);
        ResumeButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        TitleButton.gameObject.SetActive(false);

        PlayerMove.speed = tmp;
    }

    public void Restart()
    {
        BackGroundImage.gameObject.SetActive(false);
        GameClearText.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);
        ResumeButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        TitleButton.gameObject.SetActive(false);

        flag = 1;

        GameStart();
    }

}
