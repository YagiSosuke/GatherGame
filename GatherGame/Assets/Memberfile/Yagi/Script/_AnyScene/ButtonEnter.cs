using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ボタンの中にマウスが入った時に大きくする*/
//未アタッチ

public class ButtonEnter : MonoBehaviour
{
    bool EnterF = false;
    float count = 0;

    AudioSource audio;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnterF)
        {
            if (count < 1.0f){
                count += Time.deltaTime*5;
            }
            else
            {
                count = 1.0f;
            }
        }
        else
        {
            if (count > 0.0f)
            {
                count -= Time.deltaTime*5;
            }
            else
            {
                count = 0.0f;
            }
        }

        this.gameObject.transform.localScale = Vector2.Lerp(Vector2.one, new Vector2(1.2f, 1.2f), count);
    }

    //マウスがボタンに侵入時
    public void MouseButtonEnter()
    {
        if (!EnterF)
        {
            audio.PlayOneShot(clip);
        }
        EnterF = true;
    }

    //マウスがボタンに侵入時
    public void MouseButtonExit()
    {
        EnterF = false;
    }
}
