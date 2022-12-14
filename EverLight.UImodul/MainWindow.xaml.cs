using CommunityToolkit.Mvvm.DependencyInjection;
using EverLight.UImodul.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EverLight.UImodul
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowsViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm= Ioc.Default.GetService<MainWindowsViewModel>();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json (.json)|*.json|Xml (.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                if (saveFileDialog.FileName.Split('.').Last() == "json")
                {
                    File.WriteAllText(saveFileDialog.FileName, vm.JsonString());
                }
                if (saveFileDialog.FileName.Split('.').Last() == "xml")
                {
                    File.WriteAllText(saveFileDialog.FileName, vm.XmlString());
                }
            } ;
        }
    }
}
