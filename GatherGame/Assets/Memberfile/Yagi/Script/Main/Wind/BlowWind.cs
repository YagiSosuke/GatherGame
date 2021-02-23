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

    Play playscript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        windScript = GameObject.Find("WindObject").GetComponent<WindController>();
        playscript = GetComponent<Play>();
    }

    // Update is called once per frame
    void Update()
    {
        if (windScript.WindF)
        {
            //動ける場合
            if (playscript.Move)
            {
                //風がまだ吹いていない場合
                if (!WindYetF)
                {
                    if (photonView.IsMine)
                    {
                        rb.AddForce(rb.velocity + windScript.WindAngle * windScript.WindPower);
                        WindYetF = true;
                    }
                }
            }
        }
        else
        {
            WindYetF = false;
        }
    }
}
