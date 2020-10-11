using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotCircle : MonoBehaviour
{

    private GameObject parent;
    private PlayerMove playerMove;

    private bool OnCircle;

    private Vector3 MaxCircleScale;
    private Vector3 MinCircleScale;

    [SerializeField] private float CirclePlus = 0.01f;
    [SerializeField] private float CircleMinus = 0.05f;
    [SerializeField] private float CircleMax = 20f;
    [SerializeField] private float CircleMin = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクトを取得
        parent = transform.root.gameObject;

        //親オブジェクトがPlayerならばMoveを取得
        if(parent == GameObject.FindGameObjectWithTag("Player"))
        {
           playerMove = parent.GetComponent<PlayerMove>();
        }

        OnCircle = false;

        MaxCircleScale = new Vector3(CircleMax, CircleMax, this.transform.localScale.z);
        MinCircleScale = new Vector3(CircleMin, CircleMin, this.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (OnCircle)
        {
            if (parent == GameObject.FindGameObjectWithTag("Player") || parent == GameObject.FindGameObjectWithTag("NPC"))
            {
                this.transform.localScale += new Vector3(CirclePlus, CirclePlus, 0);
            }
        }
        else
        {
            if (parent == GameObject.FindGameObjectWithTag("Player") || parent == GameObject.FindGameObjectWithTag("NPC"))
            {
                this.transform.localScale -= new Vector3(CircleMinus, CircleMinus, 0);
            }
        }

        if (this.transform.localScale.x >= MaxCircleScale.x)
        {
            this.transform.localScale = MaxCircleScale;
        }

        if (this.transform.localScale.x <= MinCircleScale.x)
        {
            this.transform.localScale = MinCircleScale;

            if (parent == GameObject.FindGameObjectWithTag("Player"))
            {
                playerMove.enabled = false;
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
        if(other.gameObject.tag == "Circle")
            OnCircle = false;  
    }
}
