using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/*足跡を表示するプログラム*/

public class WalkFoot : MonoBehaviourPunCallbacks
{
    public GameObject footPrintPrefab;
    float time = 0;
    [SerializeField] float interval = 0.35f;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                time += Time.deltaTime;
                if (time > interval)
                {
                    time = 0;
                    PhotonNetwork.Instantiate("FootPrintPrefab", transform.position, transform.rotation);
                }
            }
        }
    }
}
