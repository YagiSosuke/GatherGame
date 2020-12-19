using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ボタンを押した時に音を鳴らすスクリプト*/

public class ButtonSound : MonoBehaviour
{
    [SerializeField] GameObject SoudObject;
    GameObject Instance;

    //ボタンを押した時の音を鳴らす
    public void PlayButtonSound()
    {
        Instance = Instantiate(SoudObject.gameObject);
        Invoke("Destroy(Instance)", 1.0f);
    }
}
