using CommunityToolkit.Mvvm.DependencyInjection;
using EverLight.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EverLight.UImodul
{
    public class EmploeeIdNameConverter : IValueConverter
    {
        private static BusinessLogic businessLogic;

        static EmploeeIdNameConverter()
        {
            businessLogic = Ioc.Default.GetService<BusinessLayer.BusinessLogic>();
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            return businessLogic.EmployeeBy((int)value);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine("Nincs implementálva");
            return value;
        }
    }
}
