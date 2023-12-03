using System;
using UnityEngine;

public class LoseScreen : Screen
{
    public Action RestartButtonClicked;

    public override void Hide()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
        Button.image.raycastTarget = false;
    }

    public override void Show()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
        Button.image.raycastTarget = true;
    }

    public override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
