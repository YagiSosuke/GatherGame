using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class FubukiImage : MonoBehaviourPunCallbacks
{
    [SerializeField] bool BlowF = false;
    float count = 0;
    CanvasGroup FubukiCanvas;
    
    [SerializeField] GameObject SnowPanel1;
    [SerializeField] GameObject SnowPanel2;

    [SerializeField] Material fbkMaterial;

    // Start is called before the first frame update
    void Start()
    {
        FubukiCanvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BlowF)
        {
                count += Time.deltaTime;

                if (count < 3.0f)
                {
                    SnowPanel1.transform.localPosition = Vector2.Lerp(new Vector2(-800, 450), new Vector2(800, 0), count / 3.0f);
                    SnowPanel2.transform.localPosition = Vector2.Lerp(new Vector2(800, 450), new Vector2(-800, 0), count / 3.0f);

                }

            if (count < 0.5f)
            {
                FubukiCanvas.alpha = count * 2;
                fbkMaterial.SetFloat("_Value", Mathf.Lerp(1.0f, 0.65f, count * 2));
            }
            else if (count < 2.0f)
            {
            }
            else if (count < 3.0f)
            {
                FubukiCanvas.alpha = 3.0f - count;
                fbkMaterial.SetFloat("_Value", Mathf.Lerp(0.65f, 1.0f, count - 2.0f));
            }
            else
            {
                count = 0;
                FubukiCanvas.alpha = 0;
                BlowF = false;
                SnowPanel1.transform.localPosition = new Vector2(-800, 450);
                SnowPanel2.transform.localPosition = new Vector2(800, 450);
            }
        }
        
    }

    //吹雪が吹く
    public void FubukiAnimation()
    {
        BlowF = true;
    }
}
