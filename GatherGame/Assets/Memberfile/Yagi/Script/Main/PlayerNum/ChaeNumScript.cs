using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class ChaeNumScript : MonoBehaviourPunCallbacks, IPunObservable
{
    GameObject camera;
    [SerializeField] Text NumText;
    [SerializeField] Outline line1;

    [SerializeField] Color[] TextColor;

    int id;

    [SerializeField] float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera");

        //id設定
        if (photonView.IsMine)
        {
            id = PhotonNetwork.PlayerList.Length;
            NumText.text = id + "P";
            line1.effectColor = TextColor[id - 1];
        }        
    }

    void Update() {
        if (photonView.IsMine)
        {
            count += Time.deltaTime;

            if (count < 1.0f)
            {
                NumText.fontSize = 50;
                NumText.text = id + "P";
            }
            else if (count < 2.0f)
            {
                NumText.fontSize = 35;
                NumText.text = "あなた";
            }
            else
            {
                count = 0;
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.LookAt(camera.transform);
    }

    //データを送受信するメソッド
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //送信側
            stream.SendNext(id);
        }
        else
        {
            //受信側
            id = (int)stream.ReceiveNext();
            NumText.text = id + "P";
            line1.effectColor = TextColor[id - 1];
        }
    }
}
