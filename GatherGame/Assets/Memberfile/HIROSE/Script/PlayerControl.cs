using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] private float moveSpeed = 5.0f;        // 移動速度
    [SerializeField] private float applySpeed = 0.2f;       // 振り向きの適用速度
    [SerializeField] private PlayerCamera refCamera;  // カメラの水平回転を参照する用

    //追加
    public static int HP;
    bool check;
    bool move;//動けるかどうか
    public float span = 3f;//間隔
    public float currentTime;//時間計測

    public float speed = 10.0f;
    public Rigidbody rb;

    void Start()
    {
        check = false;
        move = true;
        HP = 100;
        currentTime = 0;

        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
        if (move)
        {
            // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
            velocity = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
                velocity.z += 1;
            if (Input.GetKey(KeyCode.A))
                velocity.x -= 1;
            if (Input.GetKey(KeyCode.S))
                velocity.z -= 1;
            if (Input.GetKey(KeyCode.D))
                velocity.x += 1;
        
        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;
        }

        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {
            // プレイヤーの回転(transform.rotation)の更新
            // 無回転状態のプレイヤーのZ+方向(後頭部)を、
            // カメラの水平回転(refCamera.hRotation)で回した移動の反対方向(-velocity)に回す回転に段々近づけます
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(refCamera.hRotation * -velocity),applySpeed);

            // プレイヤーの位置(transform.position)の更新
            // カメラの水平回転(refCamera.hRotation)で回した移動方向(velocity)を足し込みます
            transform.position += refCamera.hRotation * velocity;
        }

        //heatgauge追加
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
    /*
    void FixedUpdate()
    {
        if (move)
        {
            float x = Input.GetAxis("Horizontal") * speed;
            float z = Input.GetAxis("Vertical") * speed;
            rb.AddForce(x, 0, z);
        }
    }
    */


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
