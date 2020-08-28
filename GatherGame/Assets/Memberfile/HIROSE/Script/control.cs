using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public static int HP;
    bool check;
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        check = false;
        HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        Debug.Log(HP);

        if (!check )
        {
            HP -= 1;
        }

        if (HP >= 100)
        {
            HP = 100;
        }else if (HP < 0)
        {
            HP = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("範囲に入りました");
            HP++;
            check = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("範囲を出ました");
            check = false;
        }
    }
}
