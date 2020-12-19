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
