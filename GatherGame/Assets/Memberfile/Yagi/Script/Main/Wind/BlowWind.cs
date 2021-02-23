using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*風が吹いた時にペンギンを動かす*/

public class BlowWind : MonoBehaviour
{
    Rigidbody rb;
    WindController windScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        windScript = GameObject.Find("WindObject").GetComponent<WindController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (windScript.WindF)
        {
            if (windScript.count == 0)
            {
                rb.AddForce(rb.velocity + windScript.WindAngle * windScript.WindPower);
                //rb.AddForce(rb.velocity + new Vector3(0, 0, 300f));
            }
        }
        else
        {
            if (windScript.count == 0)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
