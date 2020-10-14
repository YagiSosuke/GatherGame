using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLstick : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] private float speed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("DS4LHorizontal");
        float z = Input.GetAxis("DS4LVertical");
        //rb.AddForce(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);

        Vector3 Ppos = transform.position;
        Ppos += new Vector3(x * speed * Time.deltaTime, 0, -z * speed * Time.deltaTime);
        transform.position = Ppos;
    }
}
