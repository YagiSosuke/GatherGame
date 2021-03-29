using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

/*プレイヤーのIDを管理する*/

public class PlayerIDController : MonoBehaviourPunCallbacks, IPunObservable
{
    bool FirstPlayerLoginF = false;

    //プレイヤー番号割り振りクラス
    [System.Serializable]
    public class PlayerJoinData
    {
        public int ActorNumber = -1;
        public bool JoinF = false;
    }
    
    //マスタークライアントのActorNumber
    [SerializeField] int MasterClientNo;

    public PlayerJoinData[] PlayerData = new PlayerJoinData[20];
    

    // Start is called before the first frame update
    void Update()
    {
        if(!FirstPlayerLoginF && photonView.IsMine)
        {
            MasterClientNo = PhotonNetwork.MasterClient.ActorNumber;
            PlayerJoin(MasterClientNo);
            FirstPlayerLoginF = true;
        }
    }


    
    //誰かが部屋に入った時
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        if (photonView.IsMine)
        {
            Debug.Log(newPlayer.ActorNumber + "の参加(Num)");
            PlayerJoin(newPlayer.ActorNumber);
        }
    }

    //誰かが部屋から出たとき
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        if (photonView.IsMine)
        {
            Debug.Log("退室確認");
            PlayerExit(otherPlayer.ActorNumber);
        }
    }

    //プレイヤー番号登録
    void PlayerJoin(int num)
    {
        for(int i = 0; i < 20; i++)
        {
            if(PlayerData[i].ActorNumber == -1)
            {
                PlayerData[i].ActorNumber = num;
                PlayerData[i].JoinF = true;
                break;
            }
        }
    }

    //プレイヤー番号削除
    void PlayerExit(int num)
    {
        for (int i = 0; i < 20; i++)
        {
            if (PlayerData[i].ActorNumber == num)
            {
                PlayerData[i].ActorNumber = -1;
                PlayerData[i].JoinF = false;
                break;
            }
        }
    }
    
    //マスタークライアントが退出したとき
    //プレイヤーリストからマスタークライアントを削除する
    public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
    {
        //自分がマスタークライアントの時のみ実行
        if (newMasterClient.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            Debug.Log("貴方がマスターです");
            for (int i = 0; i < 20; i++)
            {
                if (PlayerData[i].ActorNumber == MasterClientNo)
                {
                    Debug.Log("前のMasterClientNo" + " = " + MasterClientNo);
                    Debug.Log("PlayerData[i].ActorNumber = " + PlayerData[i].ActorNumber);
                    PlayerData[i].ActorNumber = -1;
                    Debug.Log("PlayerData[i].ActorNumber = " + PlayerData[i].ActorNumber);
                    PlayerData[i].JoinF = false;
                    Debug.Log("PlayerData[i].ActorNumber = " + PlayerData[i].JoinF);
                    break;
                }
            }
            MasterClientNo = newMasterClient.ActorNumber;
        }
    }

    //変数の同期
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //送信側
            stream.SendNext(MasterClientNo);
            stream.SendNext(FirstPlayerLoginF);
            for (int i = 0; i < 20; i++)
            {
                stream.SendNext(PlayerData[i].ActorNumber);
                stream.SendNext(PlayerData[i].JoinF);
            }
        }
        else
        {
            //受信側
            MasterClientNo = (int)stream.ReceiveNext();
            FirstPlayerLoginF = (bool)stream.ReceiveNext();
            for (int i = 0; i < 20; i++)
            {
                PlayerData[i].ActorNumber = (int)stream.ReceiveNext();
                PlayerData[i].JoinF = (bool)stream.ReceiveNext();
            }
        }
    }
}
