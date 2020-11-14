using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatGauge : MonoBehaviour
{
    GameObject image;
    [SerializeField]
    public static int gauge;
    // Start is called before the first frame update
    void Start()
    {
        //ImageをGameObjectとして取得
        image = GameObject.Find("Image");
    }

    // Update is called once per frame
    void Update()
    {
        gauge = PlayerControl.HP;
        image.GetComponent<Image>().fillAmount = gauge / 100.0f;
    }
}
