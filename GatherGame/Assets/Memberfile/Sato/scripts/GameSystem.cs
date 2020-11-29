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
        SceneManager.LoadScene("Stage");
    }

    public void Sousa()
    {
        SceneManager.LoadScene("Sousa");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
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
        SceneManager.LoadScene("Title");
    }
}
