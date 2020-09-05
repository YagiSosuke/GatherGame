using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public static int HP;
    bool check;
    bool move;//動けるかどうか
    public float speed = 3.0f;
    public float LRspeed = 3.0f;
    public float span = 3f;//間隔
    public float currentTime;//時間計測
    // Start is called before the first frame update
    void Start()
    {
        check = false;
        move = true;
        HP = 100;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * LRspeed * Time.deltaTime;
            }
            if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * LRspeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("スペースキーが押されています");
                speed = 10.0f;
                LRspeed = 1.0f;
            }
            else
            {
                speed = 3.0f;
                LRspeed = 3.0f;
            }
        }

        Debug.Log(HP);
        if (check)
        {
            currentTime += Time.deltaTime;
            if (currentTime > span)
            {
                //currentTime = 0f;
                HP += 1;
            }
        }
        else
        {
            currentTime += Time.deltaTime;
            if (currentTime > span)
            {
                //currentTime = 0f;
                HP -= 1;
            }
        }

        if (HP >= 100)
        {
            HP = 100;
        }
        if (HP < 0)
        {
            HP = 0;
            move = false;
        }
        else
        {
            move = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        currentTime = 0f;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("範囲に入りました");
            check = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("範囲を出ました");
            currentTime = 0f;
            check = false;
        }
    }
}
