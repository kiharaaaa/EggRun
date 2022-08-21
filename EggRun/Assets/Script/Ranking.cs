using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    public static List<float> ScoreRanking = new List<float>();
    public static List<KeyValuePair<string, float>> S = new List<KeyValuePair<string, float>>();

    public void SetRanking()
    {
        int n = ScoreRanking.Count;
        ScoreRanking.Reverse();

        if (n > 5) n = 5;
        for(int i = 0; i < n; i++) {
            Debug.Log(i + 1 + "位: " + ScoreRanking[i].ToString("f1"));
        }
    }
}
