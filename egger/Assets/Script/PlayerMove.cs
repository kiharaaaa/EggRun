using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float CheckPointDistance = 30.0f; // CheckPoint間の距離
    public static float speed; // 進むスピード
    public static float deltaSpeed;
    public static int level; // いくつCheckPointを通過したか
    public static int lane; // 今どのレーンにいるか、左：0 中央：1 右：2
    public GameObject MainCamera;
    public GameObject paperFubuki;
    [SerializeField] private ParticleSystem particle1;
    [SerializeField] private ParticleSystem particle2;
    [SerializeField] private ParticleSystem particle3;

    public static PlayerMove playerMove;

    void Start()
    {
        level = 1;
        lane = 1;
        speed = 3;
        deltaSpeed = 1.0f;
        playerMove = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // スクリーンショットを保存
            ScreenCapture.CaptureScreenshot("ScreenShot.png");
        }

        if ((int)this.transform.position.z > CheckPointDistance * level)
        {
            level++;
            speed += deltaSpeed;
            if(deltaSpeed > 0.1f) deltaSpeed -= 0.05f;
        }
        this.transform.position += new Vector3(0, 0, speed) * Time.deltaTime;

        if (GameSystem.GameOverFlag == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetMouseButtonDown(0))
            {
                MoveLeft();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetMouseButtonDown(1))
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

    public void PlayFubuki()
    {
        particle1.Play();
        particle2.Play();
        particle3.Play();
    }
}
