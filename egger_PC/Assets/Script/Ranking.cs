using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    public static Dictionary<string, float> RankingDictionary = new Dictionary<string, float>();
    public TextMeshProUGUI[] Name;
    public TextMeshProUGUI[] Score;
    public static Ranking ranking;

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

    void Start()
    {
        LoadPrefs();
        SetRanking();
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
    }
}
