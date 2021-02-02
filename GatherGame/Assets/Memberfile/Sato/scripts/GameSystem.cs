using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    void Start()
    {

    }
    //　スタートボタンを押したら実行する
    public void GameStart()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //機内モードなど、ネットワークエラー時
            GameObject.Find("NetworkErrorPanel").GetComponent<NetworkPanel>().OpenPanel();
        }
        else {
            //ネットワーク接続OK状態
            FadeScript.FadeIn("Stage");
        }
    }

    //ゲームスタート - 操作方法を確認する場合
    public void GameStart_OpYes()
    {
        FadeScript.FadeIn("Sousa");
    }

    //ゲームスタート - 操作方法を確認しない場合
    public void GameStart_OpNo()
    {
        FadeScript.FadeIn("Stage");
    }

    public void Sousa()
    {
        FadeScript.FadeIn("Sousa");
    }

    public void Credit()
    {
        FadeScript.FadeIn("Credit");
    }

    public void GameEnd()
    {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }

    public void Title()
    {
        FadeScript.FadeIn("Title");
    }
}
