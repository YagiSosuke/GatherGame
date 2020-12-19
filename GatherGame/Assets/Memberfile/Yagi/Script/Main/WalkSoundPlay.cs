using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*歩くときの効果音を鳴らすスクリプト*/

public class WalkSoundPlay : MonoBehaviour
{
    //移動スクリプト
    Play play;
    [SerializeField] AudioSource audio;

    //再生中かどうかのフラグ
    bool PlayF = false;

    // Start is called before the first frame update
    void Start()
    {
        play = GetComponent<Play>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if(!PlayF) audio.Play();

            PlayF = true;
        }
        else
        {
            PlayF = false;
            audio.Stop();
        }
    }
}
