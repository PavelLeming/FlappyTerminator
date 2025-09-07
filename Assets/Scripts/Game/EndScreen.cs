using System;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;

    public override void Close()
    {

        gameObject.SetActive(false);
    }

    public override void Open()
    {
        gameObject.SetActive(true);
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}