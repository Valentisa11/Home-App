using Home_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Home_App.Pages
{
   public partial class LoginPage : ContentPage
{
    // Константа для текста кнопки
    public const string BUTTON_TEXT = "Войти";
    // Переменная счетчика
    public static int loginCounter = 0;
    // Создаем объект, возвращающий свойства устройства
    IDeviceDetector detector = DependencyService.Get<IDeviceDetector>();
    public LoginPage()
    {
        InitializeComponent();

        if (Device.RuntimePlatform == Device.UWP)
            loginButton.CornerRadius = 0;
        // Изменяем внешний вид кнопки для Desktop-версии
        if (Device.Idiom == TargetIdiom.Desktop)
            loginButton.CornerRadius = 0;
        // Передаем информацию о платформе на экран
        //runningDevice.Text = detector.GetDevice();
        // Устанавливаем динамический ресурс с помощью специально метода
        infoMessage.SetDynamicResource(Label.TextColorProperty, "errorColor");
    }

    /// <summary>
    /// По клику обрабатываем счётчик и выводим разные сообщения
    /// </summary>
    private void Login_Click(object sender, EventArgs e)
    {
        if (loginCounter == 0)
        {
            loginButton.Text = $"Выполняется вход..";
        }
        else if (loginCounter > 5)
        {
            loginButton.IsEnabled = false;

            // Обновляем динамический ресурс по необходимости
            Resources["errorColor"] = Color.FromHex("#e70d4f");

            // Получаем последний дочерний элемент, используя свойство Children, затем выполняем распаковку
            var infoMessage = (Label)stackLayout.Children.Last();
            // Задаем текст элемента
            infoMessage.Text = "Слишком много попыток! Попробуйте позже";
            // Новый цвет для информационных сообщений
            var warningColor = Color.FromHex("#ffa500");
            // Добавлем в словарь.
            Resources.Add("warningColor", warningColor);

            // Используем добавленный ресурс
            //infoMessage.TextColor = (Color)Resources["warningColor"];
            // Используем добавленный глобальный ресурс
            //infoMessage.TextColor = (Color)Application.Current.Resources["errorColor"];
            // задаем красный цвет сообщения
            //infoMessage.TextColor = Color.FromRgb(255, 0, 0);

        }
        else
        {
            // Обновляем динамический ресурс по необходимости
            Resources["errorColor"] = Color.FromHex("#ff8e00");

            loginButton.Text = $"Выполняется вход...   Попыток входа: {loginCounter}";
            infoMessage.Text = $"Попыток входа: {loginCounter}";
        }

        loginCounter += 1;
    }
}
}