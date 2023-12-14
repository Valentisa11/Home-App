using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(Home_App.Droid.DeviceDetector))]
namespace Home_App.Droid
{
    public class DeviceDetector : IDeviceDetector
    {
        public string GetDevice()
        {
            // Сообщаем строку с информацией о платформе
            return $"Запущено на устройстве {Build.Product},{System.Environment.NewLine} платформа {Device.RuntimePlatform}";
        }
    }
}