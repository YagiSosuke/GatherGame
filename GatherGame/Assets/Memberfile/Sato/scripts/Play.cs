﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Play : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] public float moveSpeed = 5.0f;        // 移動速度
    [SerializeField] private float applySpeed = 0.2f;       // 振り向きの適用速度
    [SerializeField]
    private GameObject stop_ice; //氷のオブジェクト
    [SerializeField]
    private float plus_scale;  //氷のオブジェクトが大きくなる値
    private bool Initialize = true;  //氷のオブジェクトの大きさを初期化できたかどうかの判定
    PlayerCameras script;  // カメラの水平回転を参照する用
    GameObject Camera;
    Animation animator;
    public bool Move;
    public static bool Riselt;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animation>();
        Camera = GameObject.Find("Camera");
        script = Camera.GetComponent<PlayerCameras>();
        Move = true;
        Riselt = false;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector3.zero;

        //自分が生成したものの処理
        if (photonView.IsMine)
        {
            if (Move == true)
            {
                float x = Input.GetAxisRaw("Horizontal");
                float z = Input.GetAxisRaw("Vertical");
                velocity.x += x;
                velocity.z += z;

                // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
                velocity = velocity.normalized * moveSpeed * Time.deltaTime;

                // いずれかの方向に移動している場合
                if (velocity.magnitude > 0)
                {
                    animator.Play("walk");
                    // プレイヤーの回転(transform.rotation)の更新
                    // 無回転状態のプレイヤーのZ+方向(後頭部)を、
                    // カメラの水平回転(refCamera.hRotation)で回した移動の反対方向(-velocity)に回す回転に段々近づけます
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(script.hRotation * velocity) * Quaternion.Euler(0, 90, 0), applySpeed);
                    // プレイヤーの位置(transform.position)の更新
                    // カメラの水平回転(refCamera.hRotation)で回した移動方向(velocity)を足し込みます
                    //transform.position += script.hRotation * velocity;
                    if (rb.velocity.magnitude < 15)
                    {
                        rb.AddForce(script.hRotation * velocity);
                    }
                }
                else
                    animator.Play("Default Take");

                //氷が解けているとき
                Initialize = true;
                stop_ice.SetActive(false);
            }
            else {
                animator.Play("Default Take");

                if (Initialize == true)
                {
                    Debug.Log("氷のオブジェクト初期化");
                    // transformを取得
                    Transform ice_Transform = stop_ice.transform;
                    Vector3 ice_scale = ice_Transform.localScale;
                    ice_scale.x = 500;
                    ice_scale.y = 500;
                    ice_scale.z = 500;
                    ice_Transform.localScale = ice_scale;
                    stop_ice.SetActive(true);
                    Initialize = false;
                }
                if (CountDown.totalTime >= 0)
                {
                    Ice_Ctrl();
                }
            }
        }
        else
        {
            if (Move)
            {
                //氷が解けているとき
                Initialize = true;
                stop_ice.SetActive(false);
            }
            else
            {
                if (Initialize == true)
                {
                    Debug.Log("氷のオブジェクト初期化");
                    // transformを取得
                    Transform ice_Transform = stop_ice.transform;
                    Vector3 ice_scale = ice_Transform.localScale;
                    ice_scale.x = 500;
                    ice_scale.y = 500;
                    ice_scale.z = 500;
                    ice_Transform.localScale = ice_scale;
                    stop_ice.SetActive(true);
                    Initialize = false;
                }
                if (CountDown.totalTime >= 0)
                {
                    Ice_Ctrl();
                }
            }
        }
    }
    void Ice_Ctrl()
    {
        // transformを取得
        Transform ice_Transform = stop_ice.transform;
        Vector3 ice_scale = ice_Transform.localScale;
        Vector3 ice_position = ice_Transform.position;
        ice_scale.x += plus_scale;
        ice_scale.y += plus_scale;
        ice_scale.z += plus_scale;
        ice_position.y += plus_scale * 0.0015f;
        //ice_scale.x = 1;
        //ice_scale.y = 1;
        //ice_scale.z = 1;
        ice_Transform.localScale = ice_scale;
        ice_Transform.position = ice_position;
    }


    //データ送受信メソッド
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //送信側
            stream.SendNext(Move);
        }
        else
        {
            //受信側
            Move = (bool)stream.ReceiveNext();
        }
    }
}
