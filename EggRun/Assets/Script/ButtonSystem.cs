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
    public TextMeshProUGUI GameOverText;
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
        UserName = inputField.text;
        if (UserName == "") UserName = "No Name";
        inputField.text = "";
        flag = 1;
    }

    public void GameStart()
    {
        if(flag == 0) GetUserName();
        SceneManager.LoadScene("2.Play");
    }


    public void Title()
    {
        SceneManager.LoadScene("1.Title");
        flag = 0;
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
