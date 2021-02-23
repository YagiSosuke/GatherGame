using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    //風が吹く間隔
    [SerializeField] float intervalMAX = 20;
    [SerializeField] float intervalMIN = 10;
    [SerializeField] float interval;
    public float count = 0;

    //風が吹く時間
    public float WindTime = 3;

    //風の向き
    public Vector3 WindAngle;

    //風力
    public float WindPower = 300;

    //効果音
    AudioSource audio;
    [SerializeField] AudioClip windAudio;

    public bool WindF = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        WindSetting();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if (!WindF)
        {
            if (interval < count)
            {
                WindF = true;
                audio.PlayOneShot(windAudio);
                count = 0;
            }
        }
        else
        {
            if(WindTime < count)
            {
                WindF = false;
                WindSetting();
            }
        }
    }

    //風の設定
    void WindSetting()
    {
        count = 0;
        interval = Random.Range(intervalMIN, intervalMAX);

        float angle = Random.Range(0, 360);
        float rad = angle * Mathf.Deg2Rad;
        float px = Mathf.Cos(rad);
        float pz = Mathf.Sin(rad);
        WindAngle = new Vector3(px, 0, pz);

    }
}
