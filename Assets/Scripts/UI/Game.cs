using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Game : MonoBehaviour
{
    [SerializeField] private StartButton _startScreen;
    [SerializeField] private ResetButton _resetScreen;
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private Player _player;
    [SerializeField] private FirstPersonController _firstPersonController;

    private void Start()
    {
        _startScreen.Open();
        StopGame();
    }

    private void OnEnable()
    {
        _player.PauseGame += PauseGame;
        _player.UnPauseGame += UnPauseGame;
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _resetScreen.RestartButtonClick += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
        _player.Win += OnGameWin; 
    }

    private void OnDisable()
    {
        _player.PauseGame -= PauseGame;
        _player.UnPauseGame -= UnPauseGame;
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
        SceneManager.LoadScene("SampleScene");
        StartGame();
    }

    private void StartGame()
    {
        ReturnGame();
    }

    private void OnGameOver()
    {
        _resetScreen.Open();
        StopGame();
    }

    private void OnGameWin()
    {
        _winScreen.Open();
        StopGame();
    }

    public void PauseGame()
    {
        _resetScreen.Open();
        StopGame();
    }

    public void UnPauseGame()
    {
        _resetScreen.Close();
         ReturnGame();
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        _firstPersonController.enabled = false;
    }

    private void ReturnGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _firstPersonController.enabled = true;
    }
}
