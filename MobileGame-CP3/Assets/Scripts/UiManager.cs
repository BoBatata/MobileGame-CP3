using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(GoToGameScene);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void GoToGameScene()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void QuitGame()
    {
        Application.Quit();
    }

}
