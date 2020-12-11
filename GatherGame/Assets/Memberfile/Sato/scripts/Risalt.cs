using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Risalt : MonoBehaviour
{
    public GameObject Clear;
    public GameObject Over;
    void Start()
    {
        Clear.SetActive(false);
        Over.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Play.Riselt == true)
            Clear.SetActive(true);
        else if (Play.Riselt == false)
            Over.SetActive(true);
    }
}
