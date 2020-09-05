using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private float XTime;
    private float ZTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        XTime = ZTime = 0; 

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(x != 0)
        {
            if(x == 1f)
                XTime += Time.deltaTime * 2f;
            if (x == -1f)
                XTime -= Time.deltaTime * 2f;

            if (XTime >= 4f)
                XTime = 4f;
            if (XTime <= -4f)
                XTime = -4f;
        }

        if (z != 0)
        {
            if (z == 1f)
                ZTime += Time.deltaTime;
            if (z == -1f)
                ZTime -= Time.deltaTime;

            if (ZTime >= 2.5f)
                ZTime = 2.5f;
            if (ZTime <= -2.5f)
                ZTime = -2.5f;
        }

        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x + XTime, playerPos.y + 30, playerPos.z - 35 + ZTime);
    }
}
