using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*歩くときの効果音を鳴らすスクリプト*/

public class PenguinSoundPlay : MonoBehaviour
{
    //移動スクリプト
    Play play;
    AudioSource audio;
    [SerializeField] AudioSource iceAudio;

    [SerializeField] AudioClip WalkAudio;
    [SerializeField] AudioClip FleezeAudio;
    [SerializeField] AudioClip UnfleezeAudio;

    //再生中かどうかのフラグ
    bool WalkPlayF = false;
    bool FleezePlayF;

    // Start is called before the first frame update
    void Start()
    {
        play = GetComponent<Play>();
        audio = GetComponent<AudioSource>();

        FleezePlayF = false;
    }

    // Update is called once per frame
    void Update()
    {
        //凍っていないとき
        if (play.Move)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                //再生されていない場合
                if (!WalkPlayF)
                {
                    audio.clip = WalkAudio;
                    audio.Play();
                }

                WalkPlayF = true;
            }
            else
            {
                WalkPlayF = false;
                audio.Stop();
            }
            //氷が割れた音
            if (FleezePlayF)
            {
                iceAudio.PlayOneShot(UnfleezeAudio);
                FleezePlayF = false;
            }
        }
        //凍った場合
        else
        {
            if (!FleezePlayF)
            {
                audio.Stop();
                iceAudio.PlayOneShot(FleezeAudio);
                FleezePlayF = true;
            }
            WalkPlayF = false;
        }
    }
}
