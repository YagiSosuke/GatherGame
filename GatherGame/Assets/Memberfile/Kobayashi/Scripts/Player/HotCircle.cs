using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotCircle : MonoBehaviour
{

    private GameObject parent;
    private PlayerMove playerMove;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Circle")
            if (parent == GameObject.FindGameObjectWithTag("Player"))
                playerMove.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Circle")
            if (parent == GameObject.FindGameObjectWithTag("Player"))
                playerMove.enabled = false;
    }
}
