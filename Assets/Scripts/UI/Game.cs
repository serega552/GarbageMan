using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Game : MonoBehaviour
{
    private const string _mainScene = "SampleScene";

    [SerializeField] private StartButton _startScreen;
    [SerializeField] private ResetButton _resetScreen;
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private Player _player;
    [SerializeField] private Pause _pause;
    [SerializeField] private FirstPersonController _firstPersonController;

    private void Start()
    {
        _startScreen.Open();
        Stop();
    }

    private void OnEnable()
    {
        _pause.PauseGame += Pause;
        _pause.UnPauseGame += UnPause;
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _resetScreen.RestartButtonClick += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
        _player.Win += OnGameWin; 
    }

    private void OnDisable()
    {
        _pause.PauseGame -= Pause;
        _pause.UnPauseGame -= UnPause;
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _resetScreen.RestartButtonClick -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
        _player.Win -= OnGameWin; 
    }

    private void OnPlayButtonClick()
    {
        _winScreen.Close();
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _resetScreen.Close();
        SceneManager.LoadScene(_mainScene);
        StartGame();
    }

    private void StartGame()
    {
        Return();
    }

    private void OnGameOver()
    {
        _resetScreen.Open();
        Stop();
    }

    private void OnGameWin()
    {
        _winScreen.Open();
        Stop();
    }

    public void Pause()
    {
        _resetScreen.Open();
        Stop();
    }

    public void UnPause()
    {
        _resetScreen.Close();
         Return();
    }

    private void Stop()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        _firstPersonController.enabled = false;
    }

    private void Return()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _firstPersonController.enabled = true;
    }
}
