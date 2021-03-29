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

    PlayerIDController IDcontroller;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera");
        IDcontroller = GameObject.Find("PlayerNumObj").GetComponent<PlayerIDController>();

        Invoke("PlayerNoSet", 0.2f);
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log("IDcontroller.GetID(photonView.ViewID) = " + IDcontroller.GetID(photonView.ViewID));
        gameObject.transform.LookAt(camera.transform);
    }
    
    //頭上のプレイヤー番号セット
    void PlayerNoSet()
    {
        if (photonView.IsMine)
        {
            YouText.SetActive(true);
            for(int i = 0; i < 20; i++)
            {
                //Debug.Log(i + " = " + IDcontroller.PlayerData[i].ActorNumber);
                if (IDcontroller.PlayerData[i].ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
                {

                    id = i + 1;
                    break;
                }
            }
            //Debug.Log("id = " + id);
            NumText.text = id + "P";
            line1.effectColor = line2.effectColor = TextColor[id - 1];
        }
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
