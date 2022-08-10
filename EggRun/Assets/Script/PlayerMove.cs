using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float CheckPointDistance = 10.0f; // CheckPoint間の距離
    public float speed; // 進むスピード
    double level; // いくつCheckPointを通過したか
    public static int lane; // 今どのレーンにいるか、左：0 中央：1 右：2
    public GameObject MainCamera;

    void Start()
    {
        level = 1;
        lane = 1;
    }

    void Update()
    {
        if((int)this.transform.position.z > CheckPointDistance * level)
        {
            level++;
            speed *= 1.1f;
        }
        this.transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
    }

    public void MoveLeft()
    {
        if (lane != 0)
        {
            this.transform.position += new Vector3(-2, 0, 0);
            MainCamera.transform.position += new Vector3(2, 0, 0);
            lane --;
        }
    }

    public void MoveRight()
    {
        if (lane != 2)
        {
            this.transform.position += new Vector3(2, 0, 0);
            MainCamera.transform.position += new Vector3(-2, 0, 0);
            lane ++;
        }
    }
}
