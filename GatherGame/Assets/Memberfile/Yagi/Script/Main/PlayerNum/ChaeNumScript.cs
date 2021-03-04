using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

/*頭上に表示するプレイヤーナンバーを管理する*/

public class ChaeNumScript : MonoBehaviourPunCallbacks, IPunObservable
{
    GameObject camera;
    [SerializeField] Text NumText;
    [SerializeField] GameObject YouText;
    [SerializeField] Outline line1;
    [SerializeField] Outline line2;

    [SerializeField] Color[] TextColor;

    int id;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera");

        //id設定
        if (photonView.IsMine)
        {
            YouText.SetActive(true);
            id = PhotonNetwork.CountOfPlayers;
            NumText.text = id + "P";
            line1.effectColor = line2.effectColor = TextColor[id - 1];
        }        
        
        
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log("IDcontroller.GetID(photonView.ViewID) = " + IDcontroller.GetID(photonView.ViewID));
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
