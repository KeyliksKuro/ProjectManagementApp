using ProjectManagementApp.Model;
using ProjectManagementApp.Services.Commands;
using ProjectManagementApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagementApp.ViewModel
{
    class MainWindowVM : ViewModelBase
    {
        public ObservableCollection<Employee> Employees { get; set; }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        public MainWindowVM()
        {
            Employees = DataWorker.GetAllEmployees();
        }


        #region COMMAND
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Employee employee = new Employee();
                      EditEmployeeVM windowVM = new EditEmployeeVM(employee);

                      EditEmployeeWindow window = new EditEmployeeWindow();
                      window.DataContext = windowVM;

                      window.Owner = Application.Current.MainWindow;
                      window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                      if(window.ShowDialog() == true)
                      {
                          Employees.Add(employee);
                      }
                  }));
            }
        }
        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(obj =>
                  {
                      Employee employee = DataWorker.CopyEmployee(SelectedEmployee);
                      EditEmployeeVM windowVM = new EditEmployeeVM(employee);

                      EditEmployeeWindow window = new EditEmployeeWindow();
                      window.DataContext = windowVM;

                      window.Owner = Application.Current.MainWindow;
                      window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                      if (window.ShowDialog() == true)
                      {
                          DataWorker.EditEmployee(SelectedEmployee, employee);
                          (obj as ListView)?.Items.Refresh();
                      }
                  },
                  (obj) => SelectedEmployee != null));
            }
        }

        #endregion
    }
}
