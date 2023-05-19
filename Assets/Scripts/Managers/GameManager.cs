using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;
    [SerializeField] private bool _isVictory = false;

    private void Start()
    {
        EventManager.instance.OnGameOver += OnGameOver;
    }

    private void OnGameOver(bool isVictory)
    {
        _isGameOver = true;
        _isVictory = isVictory;
        GlobalVictory.instance.isVictory = _isVictory;
        Debug.Log("game over");
        Invoke("LoadEndGameScene", 0.4f);
        
    }

    private void LoadEndGameScene() => SceneManager.LoadScene(UnityScenes.EndGame.ToString());
}
