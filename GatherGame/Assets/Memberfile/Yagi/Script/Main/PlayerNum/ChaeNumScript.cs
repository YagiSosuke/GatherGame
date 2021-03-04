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

    [SerializeField] int id;
    bool NumSetF = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera");

        //id設定
        if (photonView.IsMine)
        {
            id = PhotonNetwork.PlayerList.Length;
            NumText.text = id + "P";
            line1.effectColor = TextColor[id];
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
        if (!NumSetF)
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
                line1.effectColor = TextColor[id + 1];
            }
            Debug.Log("id = " + id);
        }
    }
}
