using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    private bool _isPause = false;

    public event UnityAction PauseGame;
    public event UnityAction UnPauseGame;

    private void Update()
    {
        if (Input.GetButtonDown("Pause") && _isPause)
        {
            PauseGame?.Invoke();
            _isPause = false;
        }
        else if (Input.GetButtonDown("Pause") && _isPause == false)
        {
            UnPauseGame?.Invoke();
            _isPause = true;
        }
    }
}
