<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float CheckPointDistance = 30.0f; // CheckPoint間の距離
    public static float speed; // 進むスピード
    public static int level; // いくつCheckPointを通過したか
    public static int lane; // 今どのレーンにいるか、左：0 中央：1 右：2
    public GameObject MainCamera;
    public GameObject paperFubuki;
    float paperFubukiDistance;
    int cntForPaperFubuki;
    [SerializeField] private ParticleSystem particle1;
    [SerializeField] private ParticleSystem particle2;
    [SerializeField] private ParticleSystem particle3;

    void Start()
    {
        level = 1;
        lane = 1;
        speed = 3;
        paperFubukiDistance = 10.0f;
        cntForPaperFubuki = 1;
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

        if ((int)this.transform.position.z + 0.5 > paperFubukiDistance * cntForPaperFubuki)
        {
            cntForPaperFubuki++;
            particle1.Play();
            particle2.Play();
            particle3.Play();
        }
        //if ((int)this.transform.position.z > cntForPaperFubuki * cntForPaperFubuki - 2.0f)
        //{
        //    paperFubuki.SetActive(false);
        //}
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
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float CheckPointDistance = 30.0f; // CheckPoint間の距離
    public static float speed; // 進むスピード
    public static int level; // いくつCheckPointを通過したか
    public static int lane; // 今どのレーンにいるか、左：0 中央：1 右：2
    public GameObject MainCamera;
    public GameObject paperFubuki;
    float paperFubukiDistance;
    int cntForPaperFubuki;
    [SerializeField] private ParticleSystem particle1;
    [SerializeField] private ParticleSystem particle2;
    [SerializeField] private ParticleSystem particle3;

    void Start()
    {
        level = 1;
        lane = 1;
        speed = 3;
        paperFubukiDistance = 10.0f;
        cntForPaperFubuki = 1;
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

        if ((int)this.transform.position.z + 0.5 > paperFubukiDistance * cntForPaperFubuki)
        {
            cntForPaperFubuki++;
            particle1.Play();
            particle2.Play();
            particle3.Play();
        }
        //if ((int)this.transform.position.z > cntForPaperFubuki * cntForPaperFubuki - 2.0f)
        //{
        //    paperFubuki.SetActive(false);
        //}
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
>>>>>>> 993696d61a49981913e1b2b6e6cd1410e08bf2bf
