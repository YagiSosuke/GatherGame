using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class PurposeText : MonoBehaviourPunCallbacks
{
    public Text purposeText;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (photonView.IsMine)
        //{
            if (!HotCircles.CountDown)
                purposeText.text = "無事に群れに帰ろう!";
            else
                purposeText.text = "急いで助けてもらおう!";
        //}
    }
}