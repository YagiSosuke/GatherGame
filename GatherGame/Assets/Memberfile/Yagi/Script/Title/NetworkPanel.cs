using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*ネット接続が悪かった時のパネル操作*/

public class NetworkPanel : MonoBehaviour
{
    bool OpenF = false;
    float count = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenF)
        {
            count += Time.deltaTime;

            if(count > 1.0f)
            {
                count = 1.0f;
            }
            gameObject.transform.localScale = Vector2.Lerp(Vector2.zero, Vector2.one, 1 - Mathf.Pow(1 - count, 3));
        }
        else
        {
            count -= Time.deltaTime;

            if (count < 0.0f)
            {
                count = 0.0f;
            }
            gameObject.transform.localScale = Vector2.Lerp(Vector2.zero, Vector2.one, Mathf.Pow(count, 3));
        }

    }

    //パネルを表示
    public void OpenPanel()
    {
        OpenF = true;
    }

    //パネルを閉じる
    public void ClosePanel()
    {
        OpenF = false;
    }
}
