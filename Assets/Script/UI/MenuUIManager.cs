using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject musicHolder;
    [SerializeField] private Button startGame;
    [SerializeField] private Button quitGame;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(musicHolder);
        startGame.onClick.AddListener(StartGame);
        quitGame.onClick.AddListener(EndGame);
    }

    private void EndGame()
    {
       Application.Quit();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void OnDestroy(){
        startGame.onClick.AddListener(StartGame);
        quitGame.onClick.AddListener(EndGame);
    }
}
