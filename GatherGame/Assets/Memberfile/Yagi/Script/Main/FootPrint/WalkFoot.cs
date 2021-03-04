using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*足跡を表示するプログラム*/

public class WalkFoot : MonoBehaviour
{
    public GameObject footPrintPrefab;
    float time = 0;
    [SerializeField] float interval = 0.35f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            time += Time.deltaTime;
            if (time > interval)
            {
                time = 0;
                Instantiate(footPrintPrefab, transform.position, transform.rotation);
            }
        }
    }
}
