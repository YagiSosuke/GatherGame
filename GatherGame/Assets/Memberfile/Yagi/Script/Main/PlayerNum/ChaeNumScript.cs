using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class ChaeNumScript : MonoBehaviour
{
    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera");
        PhotonNetwork.player.ID
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.LookAt(camera.transform);
    }
}
