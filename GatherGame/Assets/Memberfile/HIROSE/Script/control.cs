﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public static int HP;
    bool check;
    public float speed = 3.0f;
    public float span = 3f;//間隔
    public float currentTime;//時間計測
    // Start is called before the first frame update
    void Start()
    {
        check = false;
        HP = 100;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
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
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        Debug.Log(HP);
        if (check)
        {
            currentTime += Time.deltaTime;
            if (currentTime > span)
            {
                //currentTime = 0f;
                Debug.Log("回復します");
                HP += 1;
            }
        }
        else
        {
            currentTime += Time.deltaTime;
            if (currentTime > span)
            {
                //currentTime = 0f;
                Debug.Log("ダメージを受けます");
                HP -= 1;
            }
        }

        if (HP >= 100)
        {
            HP = 100;
        }else if (HP < 0)
        {
            HP = 0;
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
