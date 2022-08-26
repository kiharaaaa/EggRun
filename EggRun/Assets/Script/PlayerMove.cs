using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float CheckPointDistance = 10.0f; // CheckPoint間の距離
    public static float speed; // 進むスピード
    public static int level; // いくつCheckPointを通過したか
    public static int lane; // 今どのレーンにいるか、左：0 中央：1 右：2
    public GameObject MainCamera;

    void Start()
    {
        level = 1;
        lane = 1;
        speed = 3;
    }

    void Update()
    {
        if((int)this.transform.position.z > CheckPointDistance * level)
        {
            level++;
            speed *= 1.2f;
        }
        this.transform.position += new Vector3(0, 0, speed) * Time.deltaTime;

        if (GameSystem.GameOverFlag == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
            }
        }
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
