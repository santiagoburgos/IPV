using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    private bool _isVictory;
    [SerializeField] private TextMeshProUGUI result;
    [SerializeField] private GameObject retryButtonGO;
    void Start()
    {
        _isVictory = GlobalVictory.instance.isVictory;

        if (_isVictory)
        {
            result.text = "VICTORY";
            retryButtonGO.SetActive(false);
        }
        else
        {
            result.text = "DEFEAT";
        }
    }

    public void ActionMainMenu() => SceneManager.LoadScene(UnityScenes.MainMenu.ToString());
    
    public void ActionLoadLevel() => SceneManager.LoadScene(GlobalVictory.instance.lastLevel.ToString());
}
