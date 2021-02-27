using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*フェードイン、フェードアウトをするスクリプト*/

public class FadeScript : MonoBehaviour
{
    //フェード時に表示させるキャンバス
    [Header("Fade Canvas status")]
    [SerializeField] GameObject FadeCanvas;
    Image img;
    [SerializeField] Color Panelcolor = Color.black;
    GameObject Instance;
    
    [Space(10)]
    //フェードの速度管理
    float FadeSpeed = 3;
    public static float count = 0;

    //フェード処理のフラグ
    public static bool FadeInF = false;
    public static bool FadeOutF = false;

    //次シーン名
    public static string SceneName = "";

    void Start()
    {
        Instance = Instantiate(FadeCanvas.gameObject);
        img = Instance.transform.GetChild(0).GetComponent<Image>();
        img.color = new Color(Panelcolor.r, Panelcolor.g, Panelcolor.b, 0);
        FadeOut();
    }

    void Update()
    {
        if (FadeInF && !FadeOutF)
        {
            if (count == 0) Instance.SetActive(true);

            count += Time.deltaTime * FadeSpeed;

            img.color = new Color(Panelcolor.r, Panelcolor.g, Panelcolor.b, count);

            if(count > 1.0f)
            {
                FadeInF = false;
                count = 0;
                SceneManager.LoadScene(SceneName);            
            }
        }
        else if (FadeOutF)
        {
            if (count == 0) Instance.SetActive(true);

            count += Time.deltaTime * FadeSpeed;

            img.color = new Color(Panelcolor.r, Panelcolor.g, Panelcolor.b, 1 - count);

            if (count > 1.0f)
            {
                FadeOutF = false;
                count = 0;
                Instance.SetActive(false);
            }
        }
    }

    //フェードインさせる
    public static void FadeIn(string NextScene)
    {
        FadeInF = true;
        count = 0;
        SceneName = NextScene;
    }

    //フェードアウトさせる & 画面遷移
    public static void FadeOut()
    {
        FadeOutF = true;
        count = 0;        
    }
}
