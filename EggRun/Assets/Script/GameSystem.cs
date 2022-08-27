<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSystem : MonoBehaviour
{
    public Text ScoreText;

    public float TargetDistance;
    int count;
    public GameObject[] TargetPrefab;
    int ans;
    public GameObject Player;
    int r;

    public Image BackGroundImage;
    public Text GameOverText;
    public Button RestartButton;
    public Button TitleButton;

    GameObject leftTarget;
    GameObject centerTarget;
    GameObject rightTarget;
    Animator ansAnim;
    Animator dest1;
    Animator dest2;
    int animFlag = 0;

    public static int GameOverFlag = 0;

    public Text ReadyText;
    public Text GoText;
    public Image DisplayImage;

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
        { 8, 1, 0, 4, 8}
    };

    void Set()
    {
        if (animFlag == 1)
        {
            if (ans == 0) { ansAnim = leftTarget.GetComponent<Animator>(); dest1 = centerTarget.GetComponent<Animator>(); dest2 = rightTarget.GetComponent<Animator>(); }
            if (ans == 1) { ansAnim = centerTarget.GetComponent<Animator>(); dest1 = leftTarget.GetComponent<Animator>(); dest2 = rightTarget.GetComponent<Animator>(); }
            if (ans == 2) { ansAnim = rightTarget.GetComponent<Animator>(); dest1 = leftTarget.GetComponent<Animator>(); dest2 = centerTarget.GetComponent<Animator>(); }

            ansAnim.Play("Base Layer.Target", 0, 0.0f);
            dest1.Play("Base Layer.FadeOut", 0, 0.0f);
            dest2.Play("Base Layer.FadeOut", 0, 0.0f);
        }
        else animFlag = 1;

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

        leftTarget = Instantiate(TargetPrefab[choice[0]], new Vector3(-2.0f, 0.5f, TargetDistance * count), Quaternion.identity);
        centerTarget = Instantiate(TargetPrefab[choice[1]], new Vector3(0.0f, 0.5f, TargetDistance * count), Quaternion.identity);
        rightTarget = Instantiate(TargetPrefab[choice[2]], new Vector3(2.0f, 0.5f, TargetDistance * count), Quaternion.identity);

        if (choice[0] == 2 || choice[0] == 5 || choice[0] == 8) { leftTarget.transform.Rotate(0, 90, 0); }
        if (choice[1] == 2 || choice[1] == 5 || choice[1] == 8) { centerTarget.transform.Rotate(0, 90, 0); }
        if (choice[2] == 2 || choice[2] == 5 || choice[2] == 8) { rightTarget.transform.Rotate(0, 90, 0); }

    }

    void GoodBye()
    {
        GoText.gameObject.SetActive(false);
    }

    void ReadyGo()
    {
        BackGroundImage.gameObject.SetActive(false);
        ReadyText.gameObject.SetActive(false);
        DisplayImage.gameObject.SetActive(true);
        GoText.gameObject.SetActive(true);
        ScoreText.gameObject.SetActive(true);
        Invoke("GoodBye", 0.7f);
    }

    private void Start()
    {
        BackGroundImage.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        TitleButton.gameObject.SetActive(false);
        DisplayImage.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(false);

        ScoreText.text = "Score : " + 0;
        count = 0;
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSystem : MonoBehaviour
{
    public Text ScoreText;

    public float TargetDistance;
    int count;
    public GameObject[] TargetPrefab;
    int ans;
    public GameObject Player;
    int r;

    public Image BackGroundImage;
    public Text GameOverText;
    public Button RestartButton;
    public Button TitleButton;

    GameObject leftTarget;
    GameObject centerTarget;
    GameObject rightTarget;
    Animator ansAnim;
    Animator dest1;
    Animator dest2;
    int animFlag = 0;


    public static int GameOverFlag = 0;

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
        { 8, 1, 0, 4, 8}
    };

    void Set()
    {
        if (animFlag == 1)
        {
            if (ans == 0) { ansAnim = leftTarget.GetComponent<Animator>(); dest1 = centerTarget.GetComponent<Animator>(); dest2 = rightTarget.GetComponent<Animator>(); }
            if (ans == 1) { ansAnim = centerTarget.GetComponent<Animator>(); dest1 = leftTarget.GetComponent<Animator>(); dest2 = rightTarget.GetComponent<Animator>(); }
            if (ans == 2) { ansAnim = rightTarget.GetComponent<Animator>(); dest1 = leftTarget.GetComponent<Animator>(); dest2 = centerTarget.GetComponent<Animator>(); }

            ansAnim.Play("Base Layer.Target", 0, 0.0f);
            dest1.Play("Base Layer.FadeOut", 0, 0.0f);
            dest2.Play("Base Layer.FadeOut", 0, 0.0f);
        }
        else animFlag = 1;

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

        leftTarget = Instantiate(TargetPrefab[choice[0]], new Vector3(-2.0f, 0.5f, TargetDistance * count), Quaternion.identity);
        centerTarget = Instantiate(TargetPrefab[choice[1]], new Vector3(0.0f, 0.5f, TargetDistance * count), Quaternion.identity);
        rightTarget = Instantiate(TargetPrefab[choice[2]], new Vector3(2.0f, 0.5f, TargetDistance * count), Quaternion.identity);

        if (choice[0] == 2 || choice[0] == 5 || choice[0] == 8) { leftTarget.transform.Rotate(0, 90, 0); }
        if (choice[1] == 2 || choice[1] == 5 || choice[1] == 8) { centerTarget.transform.Rotate(0, 90, 0); }
        if (choice[2] == 2 || choice[2] == 5 || choice[2] == 8) { rightTarget.transform.Rotate(0, 90, 0); }

    }

    private void Start()
    {
        BackGroundImage.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        TitleButton.gameObject.SetActive(false);

        ScoreText.text = "Score : " + 0;
        count = 0;
>>>>>>> 993696d61a49981913e1b2b6e6cd1410e08bf2bf
        GameOverFlag = 0;


<<<<<<< HEAD
        GoText.gameObject.SetActive(false);
        BackGroundImage.gameObject.SetActive(true);
        ReadyText.gameObject.SetActive(true);
        Invoke("ReadyGo", 1.2f);

        Set();
    }

    int flag = 0;
    void Update()
    {
        ScoreText.text = "Score : " + ((int)(Player.transform.position.z - 0.5f)) / 10;

        if (Player.transform.position.z + 0.5f >= TargetDistance * count)
        {
            if (PlayerMove.lane == ans)
            {
                Set();
            }
            else if(flag == 0)
            {
                flag = 1;
                GameOver();
            }
        }

    }

    void GameOver()
    {
        GameOverFlag = 1;
        GameOverText.text = "Score : " + (((int)Player.transform.position.z) / 10).ToString();

        ScoreText.gameObject.SetActive(false);
        BackGroundImage.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        TitleButton.gameObject.SetActive(true);
        DisplayImage.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(false);

        PlayerMove.speed = 0;

        if (Ranking.RankingDictionary.ContainsKey(ButtonSystem.UserName))
        {
            if (Ranking.RankingDictionary[ButtonSystem.UserName] < ((int)Player.transform.position.z) / 10)
            {
                Ranking.RankingDictionary.Remove(ButtonSystem.UserName);
                Ranking.RankingDictionary.Add(ButtonSystem.UserName, ((int)Player.transform.position.z) / 10);
            }
            
        }
        else
        {
            Ranking.RankingDictionary.Add(ButtonSystem.UserName, ((int)Player.transform.position.z) / 10);
        }
    }
=======
        if (Player.transform.position.z + 0.5f >= TargetDistance * count)
        {
            if (PlayerMove.lane == ans)
            {
                Set();
            }
            else if(flag == 0)
            {
                Debug.Log(r + " " + ans);
                flag = 1;
                GameOver();
            }
        }

    }

    void GameOver()
    {
        GameOverFlag = 1;
        GameOverText.text = "Score : " + (((int)Player.transform.position.z) / 10).ToString();

        ScoreText.gameObject.SetActive(false);
        BackGroundImage.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        TitleButton.gameObject.SetActive(true);

        PlayerMove.speed = 0;

        if (Ranking.RankingDictionary.ContainsKey(ButtonSystem.UserName))
        {
            if (Ranking.RankingDictionary[ButtonSystem.UserName] < ((int)Player.transform.position.z) / 10)
            {
                Ranking.RankingDictionary.Remove(ButtonSystem.UserName);
                Ranking.RankingDictionary.Add(ButtonSystem.UserName, ((int)Player.transform.position.z) / 10);
            }
            
        }
        else
        {
            Ranking.RankingDictionary.Add(ButtonSystem.UserName, ((int)Player.transform.position.z) / 10);
        }
    }
>>>>>>> 993696d61a49981913e1b2b6e6cd1410e08bf2bf
}