using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

/*プレイヤーのIDを管理する*/

public class PlayerIDController : MonoBehaviour, IPunObservable
{
    public List<int> PlayerIDs;

    // Start is called before the first frame update
    void Start()
    {
        PlayerIDs = new List<int>();
    }
    
    //新しくゲームに参加したとき
    public void login(int id)
    {
        PlayerIDs.Add(id);
    }

    //IDを取得
    public int GetID(int id)
    {
        return PlayerIDs.IndexOf(id) + 1;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //送信側
            stream.SendNext(PlayerIDs);
        }
        else
        {
            //受信側
            PlayerIDs = (List<int>)stream.ReceiveNext();
        }
    }
}
