using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*デバッグメニューのスクリプト*/

public class DebugMenuScript : MonoBehaviour
{
    bool SmallCircleF = true;

    GameObject Circle;
    HotCircles HC;
    Slider slider;

    Play playscript;

    // Start is called before the first frame update
    void Start()
    {
        Circle = gameObject.transform.parent.parent.FindChild("Circle (1)").gameObject;
        HC = Circle.GetComponent<HotCircles>();
        slider = gameObject.transform.FindChild("Image").FindChild("Slider").GetComponent<Slider>();
        playscript = gameObject.transform.parent.parent.GetComponent<Play>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //サークルが減らないボタン
    public void CircleNotDecreaseButton()
    {
        HC.OnCircle = true;
    }

    //サークルが減るボタン
    public void CircleDecreaseButton()
    {
        HC.OnCircle = false;
    }

    //スライダーが動いたら
    public void SliderMove()
    {
        //playscript.moveSpeed = slider.value * 300 + 300;
    }
}
