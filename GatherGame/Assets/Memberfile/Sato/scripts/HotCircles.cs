using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class HotCircles : MonoBehaviourPunCallbacks
{
    private GameObject parent;
    private Play playerMove;

    public bool OnCircle;

    private Vector3 MaxCircleScale;
    private Vector3 MinCircleScale;

    [SerializeField] private float CirclePlus = 0.05f;
    [SerializeField] private float CircleMinus = 0.05f;
    [SerializeField] private float CircleMax = 20f;
    [SerializeField] private float CircleMin = 0f;

    public static bool CountDown;

    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクトを取得
        parent = GameObject.Find("Penguin(Clone)");
        playerMove = parent.GetComponent<Play>();

        OnCircle = false;

        MaxCircleScale = new Vector3(CircleMax, CircleMax, this.transform.localScale.z);
        MinCircleScale = new Vector3(CircleMin, CircleMin, this.transform.localScale.z);

        CountDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (OnCircle)
            {
                this.transform.localScale += new Vector3(CirclePlus, CirclePlus, 0);
            }
            else
            {
                this.transform.localScale -= new Vector3(CircleMinus, CircleMinus, 0);
            }

            if (this.transform.localScale.x >= MaxCircleScale.x)
            {
                this.transform.localScale = MaxCircleScale;
              
            }

            if (this.transform.localScale.x <= MinCircleScale.x)
            {
                this.transform.localScale = MinCircleScale;
                playerMove.Move = false;
                CountDown = true;
            }
            else
            {
                CountDown = false;
                playerMove.Move = true;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Circle")
            OnCircle = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Circle")
            OnCircle = false;
    }
}
