using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UnityScenes
{
    [Description("MainMenu")]
    MainMenu,
    [Description("Level1")]
    Level1,
    [Description("EndGame")]
    EndGame
}
public class MenuManager : MonoBehaviour
{
    public void ActionPlay()
    {
        SceneManager.LoadScene(UnityScenes.Level1.ToString());
    }
    

    public void ActionExit() => Application.Quit();
}
