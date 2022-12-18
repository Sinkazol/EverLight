using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using EverLight.BusinessLayer;
using EverLight.DTOs;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace EverLight.UImodul.ViewModel
{
    [ObservableObject]
    public partial class MainWindowsViewModel
    {
        private readonly BusinessLogic businesLogic;
        [ObservableProperty]
        private List<Order> orders = new List<Order>();
        [ObservableProperty]
        private List<Employee> employees = new List<Employee>();
        [ObservableProperty]
        private Visibility dateSelectionVisible = Visibility.Collapsed;
        [ObservableProperty]
        private Visibility employeeSelectionVisible = Visibility.Visible;
        [ObservableProperty]
        private Visibility errorTypeVisibile = Visibility.Visible;
        private int selectedSortType;
        private int selectedMonth;
        private string selectedError;
        private Employee selectedEmployee;

        [ObservableProperty]
        private List<string> monthsNames = new List<string>();
        [ObservableProperty]
        private List<string> errorTypes = new List<string>();
        public int SelectedSortType
        {
            get { return selectedSortType; }

            set
            {
                if (selectedSortType != value)
                {
                    selectedSortType = value;

                    
                    if (value == 0)
                    {
                        EmployeeSelectionVisible = Visibility.Visible;
                        Employees = businesLogic.GetAllEmployes().ToList();
                        Orders = businesLogic.GetOrdersby(Employees.FirstOrDefault()).ToList();
                    }
                    else EmployeeSelectionVisible = Visibility.Collapsed;
                    SetProperty(ref selectedSortType, value, "SelectedSortType");
                    if (value == 1)
                    {
                        DateSelectionVisible = Visibility.Visible;
                        Orders = businesLogic.GetOrdersby(SelectedMonth + 1).ToList();
                    }
                    else DateSelectionVisible = Visibility.Collapsed;
                    if (value == 2)
                    {
                        ErrorTypeVisibile = Visibility.Visible;
                        Orders = businesLogic.GetAll().Where(x => x.Closed != null && x.ErrorType==selectedError).ToList();
                    }
                    else ErrorTypeVisibile = Visibility.Collapsed;
                    if (value == 3)
                    {
                        Orders = businesLogic.GetAll().Where(x => x.Closed != null).ToList();
                    }
                }
            }
        }

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }

            set
            {
                if (SelectedEmployee != value)
                {
                    selectedEmployee = value;
                    SetProperty(ref selectedEmployee, value, "SelectedEmployer");
                    Orders = businesLogic.GetOrdersby(value).ToList();
                }
            }
        }
        public int SelectedMonth
        {
            get { return selectedMonth; }

            set
            {
                if (SelectedMonth != value)
                {
                    selectedMonth = value;
                    SetProperty(ref selectedMonth, value, "SelectedMonth");
                    Orders = businesLogic.GetOrdersby(value + 1).ToList();
                }
            }
        }

        public string SelectedError
        {
            get { return selectedError; }

            set
            {
                if (SelectedError != value)
                {
                    selectedError = value;
                    SetProperty(ref selectedError, value, "SelectedError");
                    Orders = businesLogic.GetOrdersby(value).ToList();
                }
            }
        }

        public MainWindowsViewModel()
        {
            businesLogic = Ioc.Default.GetService<BusinessLayer.BusinessLogic>();
            Orders = businesLogic.GetAll().ToList();

            List<string> months = new List<string>();
            for (int i = 1; i < 13; i++)
            {
                months.Add(new DateTime(2010, i, 1)
                 .ToString("MMMM", CultureInfo.InvariantCulture));
            }
            MonthsNames = months;
            SelectedMonth = DateTime.Today.Month - 1;
            
           
            ErrorTypes = businesLogic.GetErrorTypes();


            Employees = businesLogic.GetAllEmployes().ToList();
            SelectedEmployee = Employees.FirstOrDefault();
            if(ErrorTypes.FirstOrDefault() != null)
            {
            SelectedError = ErrorTypes.FirstOrDefault();
            }
            SelectedSortType = 3;
        }

        public void Fill()
        {
            Orders = businesLogic.GetAll().ToList();
        }
        public string JsonString()
        {
            return JsonSerializer.Serialize(Orders.ToArray());
        }
        public string XmlString()
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(orders.ToArray().GetType());
            using StringWriter textwriter = new StringWriter();
            x.Serialize(textwriter, orders.ToArray());
            return textwriter.ToString();
        }
    }
}
