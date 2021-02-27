using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

/*風が吹いた時にペンギンを動かす*/

public class BlowWind : MonoBehaviourPunCallbacks
{
    Rigidbody rb;
    WindController windScript;
    
    //風が吹いたかどうかのフラグ
    bool WindYetF = false;

    //吹雪画像を表示するスクリプト
    FubukiImage fubukiImageScript;

    //凍ってないかどうかの判定に必要
    Play playscript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        windScript = GameObject.Find("WindObject").GetComponent<WindController>();
        playscript = GetComponent<Play>();

        fubukiImageScript = GameObject.Find("FubukiImages").GetComponent<FubukiImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (windScript.WindF)
        {
            //風がまだ吹いていない場合
            if (!WindYetF)
            {
                if (photonView.IsMine)
                {
                    fubukiImageScript.FubukiAnimation();

                    //動ける場合
                    if (playscript.Move)
                    {
                        rb.AddForce(rb.velocity + windScript.WindAngle * windScript.WindPower);
                    }
                    WindYetF = true;
                }
            }
        }
        else
        {
            WindYetF = false;
        }
    }
}
