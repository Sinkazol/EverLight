using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using EverLight.DTOs;

namespace EverLight.UImodul
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var services = new ServiceCollection();
            services.AddSingleton<EverLight.DC.DataContext>();
            services.AddSingleton<EverLight.Repositories.Repository<Order>>();
            services.AddSingleton<EverLight.Repositories.Repository<Employee>>();
            services.AddSingleton<EverLight.BusinessLayer.BusinessLogic>();
            services.AddSingleton<EverLight.UImodul.ViewModel.MainWindowsViewModel>();
            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }   
    }
    
}
