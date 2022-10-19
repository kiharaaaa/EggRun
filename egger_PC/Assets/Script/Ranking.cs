using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Ranking : MonoBehaviour
{
    public static Dictionary<string, float> RankingDictionary = new Dictionary<string, float>();
    public TextMeshProUGUI[] Name;
    public TextMeshProUGUI[] Score;
    public static Ranking ranking;

    void Start()
    {
        LoadPrefs();
        SetRanking();
    }

    /*
    public void Update()
    {
        bool tmp = Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightShift);

        if (tmp)
        {
            // bool b = EditorUtility.DisplayDialog("ランキング", "リセットしますか？", "yes", "no");
            if (b)
            {
                PlayerPrefs.DeleteAll();
                RankingDictionary = new Dictionary<string, float>();
                Start();
            }
        }
    }
    */

    public void LoadPrefs()
    {
        Name[0].text = PlayerPrefs.GetString("name0", "---------");
        Name[1].text = PlayerPrefs.GetString("name1", "---------");
        Name[2].text = PlayerPrefs.GetString("name2", "---------");
        Name[3].text = PlayerPrefs.GetString("name3", "---------");
        Name[4].text = PlayerPrefs.GetString("name4", "---------");

        Score[0].text = PlayerPrefs.GetString("score0", "---");
        Score[1].text = PlayerPrefs.GetString("score1", "---");
        Score[2].text = PlayerPrefs.GetString("score2", "---");
        Score[3].text = PlayerPrefs.GetString("score3", "---");
        Score[4].text = PlayerPrefs.GetString("score4", "---");

        for (int i = 0; i < 5; i++)
        {
            if (Name[i].text != "---------")
            {
                if (Ranking.RankingDictionary.ContainsKey(Name[i].text))
                {
                    if (RankingDictionary[Name[i].text] < float.Parse(Score[i].text)) //スコアが更新される場合
                    {
                        RankingDictionary.Remove(Name[i].text);
                        RankingDictionary.Add(Name[i].text, float.Parse(Score[i].text));
                    }
                }
                else
                {
                    RankingDictionary.Add(Name[i].text, float.Parse(Score[i].text));
                }
            }
            else
            {
                break;
            }
        }
    }

    public void SetRanking()
    {
        var sortedmap = RankingDictionary.OrderByDescending(x => x.Value);
        int count = 0;
        foreach (KeyValuePair<string, float> item in sortedmap)
        {
            Name[count].text = item.Key.ToString();
            Score[count].text = item.Value.ToString();

            count++;
            if (count == 5) break;
        }
        SavePrefs();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetString("name0", Name[0].text);
        PlayerPrefs.SetString("name1", Name[1].text);
        PlayerPrefs.SetString("name2", Name[2].text);
        PlayerPrefs.SetString("name3", Name[3].text);
        PlayerPrefs.SetString("name4", Name[4].text);

        PlayerPrefs.SetString("score0", Score[0].text);
        PlayerPrefs.SetString("score1", Score[1].text);
        PlayerPrefs.SetString("score2", Score[2].text);
        PlayerPrefs.SetString("score3", Score[3].text);
        PlayerPrefs.SetString("score4", Score[4].text);

        PlayerPrefs.Save();
    }

}
