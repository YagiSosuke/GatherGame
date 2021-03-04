using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class CountDown : MonoBehaviourPunCallbacks
{
    public Text timerText;

    public static float totalTime;
    public float ResetTime;
    int seconds;

    private GameObject parent;

    // Use this for initialization
    void Start()
    {
        parent = GameObject.Find("Penguin(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (HotCircles.CountDown == true)
            {
                totalTime -= Time.deltaTime;
                seconds = (int)totalTime;
                timerText.text = "<size=20>完全に凍りつくまで</size>\n<size=100>" + seconds + "</size>\n"+ "<size=20>仲間に助けてもらおう</size>";
            }
            else
            {
                totalTime = ResetTime;
                timerText.text = " ";
            }

            if (totalTime <= 0)
            {
                parent.gameObject.SetActive(false);
            }
            if (totalTime <0)
            {
                PhotonNetwork.Disconnect();     //八木が追加,Photonネットワークから切断
                SceneManager.LoadScene("Risalt");
            }
        }
    }
}
