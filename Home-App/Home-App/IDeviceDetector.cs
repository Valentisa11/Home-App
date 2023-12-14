using System;
using System.Collections.Generic;
using System.Text;

namespace Home_App
{
    /// <summary>
    /// Общий интерфейс для классов отдельных платформ
    /// </summary>
    public interface IDeviceDetector
{
    /// <summary>
    /// Получение информации об устройстве
    /// </summary>
    string GetDevice();
}
}
