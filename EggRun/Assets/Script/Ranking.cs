using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Ranking : MonoBehaviour
{
    public static List<float> ScoreRanking2 = new List<float>();
    public static Dictionary<string, float> RankingDictionary = new Dictionary<string, float>();
    public TextMeshProUGUI[] Name;
    public TextMeshProUGUI[] Score;

    public void SetRanking()
    {
        var sortedmap = RankingDictionary.OrderByDescending(x => x.Value);

        int count = 0;
        foreach (KeyValuePair<string, float> item in sortedmap)
        {
            count++;
            Debug.Log(count + "位  UserName：" + item.Key + " Score：" + item.Value);
            Name[count].text = item.Key.ToString();
            Score[count].text = item.Value.ToString();

            if (count == 5) break;
        }
    }
}
