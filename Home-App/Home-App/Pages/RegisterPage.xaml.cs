using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Home_App.Pages
{
   /// <summary>
    /// Действие триггера, меняющее цвет текста, пока поле заполнено неверно
    /// </summary>
    public class EmailTriggerAction : TriggerAction<Entry>
{
    protected override void Invoke(Entry emailField)
    {
        if (emailField.IsFocused)
        {
            emailField.TextColor = emailField.Text.Contains("@") && emailField.Text.Contains(".") ? Color.AliceBlue : Color.LightPink;
        }
    }
}
public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        PlatformAdjust();
    }

    /// <summary>
    /// Настраиваем вид для разных платформ
    /// </summary>
    public void PlatformAdjust()
    {
        if (Device.RuntimePlatform == Device.UWP)
        {
            placeHolder.PlaceholderColor = Color.SlateGray;
        }
    }
}
}