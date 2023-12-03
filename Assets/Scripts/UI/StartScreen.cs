using System;
using UnityEngine;

public class StartScreen : Screen
{
    public Action PlayButtonClicked;

    public override void Hide()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }

    public override void Show()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    public override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
