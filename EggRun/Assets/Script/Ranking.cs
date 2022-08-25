using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public static List<float> ScoreRanking2 = new List<float>();
    public static List<KeyValuePair<string, float>> ScoreRanking = new List<KeyValuePair<string, float>>();

    public void SetRanking()
    {
        int n = ScoreRanking.Count;
        ScoreRanking.Sort();
        ScoreRanking.Reverse();

        for(int i = 0; i < n; i++) {
            Debug.Log(i + 1 + "位: " + ScoreRanking[i].ToString());
        }
    }
}
