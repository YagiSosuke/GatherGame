using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*歩くときの効果音を鳴らすスクリプト*/

public class PenguinSoundPlay : MonoBehaviour
{
    //移動スクリプト
    Play play;
    AudioSource audio;

    [SerializeField] AudioClip WalkAudio;

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
            //再生されていない かつ 凍っていない場合
            if (!PlayF && play.Move)
            {
                audio.clip = WalkAudio;
                audio.Play();
            }
            //凍った場合
            else if (!play.Move) audio.Stop();

            PlayF = true;
        }
        else
        {
            PlayF = false;
            audio.Stop();
        }
    }
}
