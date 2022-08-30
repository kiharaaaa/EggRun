using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySystem : MonoBehaviour
{
    public Image image;
    public Sprite[] Target;
    public static int flag;

    void Update()
    {
        image = this.GetComponent<Image>();
        image.sprite = Target[flag];
    }
}
