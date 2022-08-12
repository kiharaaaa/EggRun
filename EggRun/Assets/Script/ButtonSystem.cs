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

    float tmp;

    public void GameStart()
    {
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

        GameStart();
    }

}
