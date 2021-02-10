using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*水に落ちる*/

public class FallInWater : MonoBehaviour
{
    Rigidbody ObjRB;
    AudioSource audio;
    [SerializeField]AudioClip DamageSound;

    // Start is called before the first frame update
    void Start()
    {
        ObjRB = gameObject.transform.parent.GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Water")
        {
            //吹っ飛ぶ方向
            Vector3 moveVec = (transform.position - col.transform.position).normalized * 3000;
            moveVec = new Vector3(moveVec.x, 0, moveVec.z);
            ObjRB.AddForce(moveVec);
            audio.PlayOneShot(DamageSound);

            Invoke("VelocityStop", 0.2f);
        }
    }

    //停止する
    void VelocityStop()
    {
        ObjRB.velocity = Vector3.zero;
    }
}
