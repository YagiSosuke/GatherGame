using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*星にマウスを乗せたとき*/

public class StarScript : MonoBehaviour
{
    bool OnF = false;
    [SerializeField] Text ScreenExplainText;

    float count = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OnF)
        {
            count += Time.deltaTime;
            if (count > 1.0f)
            {
                count = 1.0f;
            }
        }
        else
        {
            count -= Time.deltaTime;
            if (count < 0.0f)
            {
                count = 0.0f;
            }
        }

        ScreenExplainText.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, count);
    }

    public void StarEnter()
    {
        OnF = true;
    }
    public void StarExit()
    {
        OnF = false;
    }
}
