using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Play : MonoBehaviourPunCallbacks
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
        velocity =Vector3.zero;
        if (photonView.IsMine)
        {
            if (Move == true)
            {
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
}
