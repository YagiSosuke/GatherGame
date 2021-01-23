using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ボタンを押した時に音を鳴らすスクリプト*/

public class ButtonSound : MonoBehaviour
{
    AudioSource ButtonAudio;

    void Start()
    {
        ButtonAudio = GetComponent<AudioSource>();
    }

    //ボタンを押した時の音を鳴らす
    public void PlayButtonSound()
    {
        ButtonAudio.Play();
    }
}
