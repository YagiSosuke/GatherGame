using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*氷が割れる*/

public class IceBreak : MonoBehaviour
{
    bool BreakF = false;
    float Scale_x = 595;
    float count = 0;

    Vector3 BeforeScale;
    Vector3 AfterScale;

    //氷のオブジェクト
    [SerializeField] GameObject Ice;
    [SerializeField] GameObject Hole;

    //割れる効果音
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        BeforeScale = new Vector3(0, 297, 1605);
        AfterScale = new Vector3(Scale_x, 297, 1605);

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BreakF)
        {
            Ice.transform.localScale = Vector3.Lerp(BeforeScale, AfterScale, count);

            if (count < 1.0f)
            {
                count += Time.deltaTime * 5.0f;
            }
            else
            {
                count = 1.0f;
            }
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        //プレイヤーが氷が割れる範囲に侵入したとき
        if(col.tag == "Player")
        {
            if (!BreakF)
            {
                BreakF = true;
                Hole.SetActive(true);
                audio.Play();
            }
        }
    }
}
