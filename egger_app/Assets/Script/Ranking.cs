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
            // Debug.Log(count + 1 + "位  UserName：" + item.Key + " Score：" + item.Value);
            Name[count].text = item.Key.ToString();
            Score[count].text = item.Value.ToString();

            count++;
            if (count == 5) break;
        }
    }

    void Start()
    {
        SetRanking();
    }
}
