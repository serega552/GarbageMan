using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinScreen : Screen
{
    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }
    public override void Open()
    {
        CanvasGroup.alpha = 0.4f;
        Button.interactable = true;
    }

    protected override void OnButtonClick(){ }
}
