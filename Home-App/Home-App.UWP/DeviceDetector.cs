using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Xamarin.Forms;

[assembly: Dependency(typeof(Home_App.UWP.DeviceDetector))]
namespace Home_App.UWP
{
    public class DeviceDetector : IDeviceDetector
    {
        public string GetDevice()
        {
            // Создаем объект класса с информацией об устройстве
            var devInfo = new EasClientDeviceInformation();
            // Сообщаем строку с информацией о платформе
            return $"Запущено на устройстве {devInfo.SystemManufacturer},{Environment.NewLine} платформа {Device.RuntimePlatform}";
        }
    }
}