using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSystem : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LevelText;

    public float TargetDistance;
    int count;
    public GameObject[] TargetPrefab;
    int ans;
    public GameObject Player;
    public float GoalDistance;
    int r;

    public Image BackGroundImage;
    public TextMeshProUGUI GameClearText;
    public TextMeshProUGUI GameOverText;
    public Button ResumeButton;
    public Button RestartButton;
    public Button TitleButton;

    int[,] TargetArray = new int[54, 5] {  // ans, 表示, 選択肢1~3
        { 0, 0, 0, 4, 8} ,
        { 0, 0, 0, 5, 7} ,
        { 1, 1, 1, 3, 8} ,
        { 1, 1, 1, 5, 6} ,
        { 2, 2, 2, 3, 7} ,
        { 2, 2, 2, 4, 6} ,
        { 3, 3, 1, 3, 8} ,
        { 3, 3, 2, 3, 7} ,
        { 4, 4, 0, 4, 8} ,
        { 4, 4, 2, 4, 6} ,
        { 5, 5, 0, 5, 7} ,
        { 5, 5, 1, 5, 6} ,
        { 6, 6, 1, 5, 6} ,
        { 6, 6, 2, 4, 6} ,
        { 7, 7, 0, 5, 7} ,
        { 7, 7, 2, 3, 7} ,
        { 8, 8, 0, 4, 8} ,
        { 8, 8, 1, 3, 8} ,

        { 0, 4, 0, 5, 7} ,
        { 0, 5, 0, 4, 8} ,
        { 0, 7, 0, 4, 8} ,
        { 0, 8, 0, 5, 7} ,
        { 1, 3, 1, 5, 6} ,
        { 1, 5, 1, 3, 8} ,
        { 1, 6, 1, 3, 8} ,
        { 1, 8, 1, 5, 6} ,
        { 2, 3, 2, 4, 6} ,
        { 2, 4, 2, 3, 7} ,
        { 2, 6, 2, 3, 7} ,
        { 2, 7, 2, 4, 6} ,

        { 3, 1, 2, 3, 7} ,
        { 3, 2, 1, 3, 8} ,
        { 3, 7, 1, 3, 8} ,
        { 3, 8, 2, 3, 7} ,
        { 4, 0, 2, 4, 6} ,
        { 4, 2, 0, 4, 8} ,
        { 4, 6, 0, 4, 8} ,
        { 4, 8, 2, 4, 6} ,
        { 5, 0, 1, 5, 6} ,
        { 5, 1, 0, 5, 7} ,
        { 5, 6, 0, 5, 7} ,
        { 5, 7, 1, 5, 6} ,

        { 6, 4, 1, 5, 6} ,
        { 6, 5, 2, 4, 6} ,
        { 6, 1, 2, 4, 6} ,
        { 6, 2, 1, 5, 6} ,
        { 7, 3, 0, 5, 7} ,
        { 7, 5, 2, 3, 7} ,
        { 7, 0, 2, 3, 7} ,
        { 7, 2, 0, 5, 7} ,
        { 8, 3, 0, 4, 8} ,
        { 8, 4, 1, 3, 8} ,
        { 8, 0, 1, 3, 8} ,
        { 6, 1, 0, 4, 6}
    };

    void Set()
    {
        count++;

        r = Random.Range(0, 54);

        ans = TargetArray[r, 0];
        DisplaySystem.flag = TargetArray[r, 1];
        int[] choice = new int[3] {
            TargetArray[r, 2],
            TargetArray[r, 3],
            TargetArray[r, 4]
        };

        for (int i = 0; i < 3; i++)
        {
            int j = Random.Range(0, 3) % 3;
            int t = choice[i];
            choice[i] = choice[j];
            choice[j] = t;
        }

        for (int i = 0; i < 3; i++)
        {
            if (ans == choice[i])
            {
                ans = i;
                break;
            }
        }

        Instantiate(TargetPrefab[ choice[0] ], new Vector3(-2.0f, 0.5f, TargetDistance * count), Quaternion.identity);
        Instantiate(TargetPrefab[ choice[1] ], new Vector3( 0.0f, 0.5f, TargetDistance * count), Quaternion.identity);
        Instantiate(TargetPrefab[ choice[2] ], new Vector3( 2.0f, 0.5f, TargetDistance * count), Quaternion.identity);
    }

    void Start()
    {
        BackGroundImage.gameObject.SetActive(false);
        GameClearText.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);
        ResumeButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        TitleButton.gameObject.SetActive(false);

        LevelText.text = "Level : " + 0;
        ScoreText.text = "Score : " + 0 + "m";
        count = 0;
        Set();
    }

    int flag = 0;
    void Update()
    {
        LevelText.text = "Level : " + PlayerMove.level;
        ScoreText.text = "Score : " + Player.transform.position.z.ToString("f1") + "m";

        if (Player.transform.position.z - 0.5f >= TargetDistance * count)
        {
            if (PlayerMove.lane == ans)
            {
                Set();
            }
            else
            {
                if (flag == 0)
                {
                    Debug.Log(r + " " + ans);
                    flag = 1;
                    GameOver();
                }
            }
        }

        if (Player.transform.position.z - 0.5f >= GoalDistance)
        {
            Debug.Log("Goal!");
            GameClear();
        }

    }

    void GameOver()
    {
        BackGroundImage.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        TitleButton.gameObject.SetActive(true);

        PlayerMove.speed = 0;
        Ranking.ScoreRanking.Add(Player.transform.position.z);
    }

    void GameClear()
    {
        BackGroundImage.gameObject.SetActive(true);
        GameClearText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        TitleButton.gameObject.SetActive(true);

        PlayerMove.speed = 0;
    }
}