﻿using Home_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Home_App.Pages
{
    public partial class DeviceListPage : ContentPage
{
    public List<HomeDevice> Devices { get; set; } = new List<HomeDevice>();

    public DeviceListPage()
    {
        InitializeComponent();

        // Заполняем список устройств
        Devices.Add(new HomeDevice("Чайник", description: "LG, объем 2л.", image: "Chainik.png"));
        Devices.Add(new HomeDevice("Стиральная машина", description: "BOSCH", image: "StiralnayaMashina.png"));
        Devices.Add(new HomeDevice("Посудомоечная машина", description: "Gorenje", image: "PosudomoechnayaMashina.png"));
        Devices.Add(new HomeDevice("Мультиварка", description: "Philips", image: "Multivarka.png"));

        BindingContext = this;
    }

    /// <summary>
    /// Обработчик нажатия
    /// </summary>
    private void deviceList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        // распаковка модели из объекта
        var tappedDevice = (HomeDevice)e.Item;
        // уведомление
        DisplayAlert("Нажатие", $"Вы нажали на элемент {tappedDevice.Name}", "OK"); ; ;
    }

    /// <summary>
    /// Обработчик выбора
    /// </summary>
    private void deviceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // распаковка модели из объекта
        var selectedDevice = (HomeDevice)e.SelectedItem;
        // уведомление
        DisplayAlert("Выбор", $"Вы выбрали {selectedDevice.Name}", "OK"); ; ;
    }
    /// <summary>
    /// Обработчик добавления нового устройства
    /// </summary>
    private async void AddDevice(object sender, EventArgs e)
    {
        // Запрос и валидация имени устройства
        var newDeviceName = await DisplayPromptAsync("Новое устройство", "Введите имя устройства", "Продолжить", "Отмена");
        if (Devices.Any(d => d.Name.CompareTo(newDeviceName.Trim()) == 0))
        {
            await DisplayAlert("Ошибка", $"Устройство '{newDeviceName}' уже существует", "ОК");
            return;
        }

        // Запрос описания устройства
        var newDeviceDescription = await DisplayPromptAsync(newDeviceName, "Добавьте краткое описание устройства", "Сохранить", "Отмена");

        // Добавление устройства и уведомление пользователя
        Devices.Add(new HomeDevice(newDeviceName, description: newDeviceDescription));
        await DisplayAlert(null, $"Устройство '{newDeviceName}' успешно добавлено", "ОК");
    }

    /// <summary>
    /// Обработчик удаления устройства
    /// </summary>
    private async void RemoveDevice(object sender, EventArgs e)
    {
        // Получаем и "распаковываем" выбранный элемент
        var deviceToRemove = deviceList.SelectedItem as HomeDevice;
        if (deviceToRemove != null)
        {
            // Удаляем
            Devices.Remove(deviceToRemove);
            // Уведомляем пользователя
            await DisplayAlert(null, $"Устройство '{deviceToRemove.Name}' удалено", "ОК");
        }
    }
}

}
