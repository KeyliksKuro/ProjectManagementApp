using ProjectManagementApp.Model;
using ProjectManagementApp.Utilities;
using ProjectManagementApp.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace ProjectManagementApp.ViewModel
{
    class EmployeesTabVM : ViewModelBase
    {
        private Employee? selectedEmployee;
        public ObservableCollection<Employee> Employees { get; set; }

        public Employee? SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        public EmployeesTabVM()
        {
            Employees = DataWorker.GetAllEmployees();
        }

        #region MENU COMMANDS
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Employee employee = new Employee();
                      EditEmployee(employee, () => Employees.Add(employee));
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
                      Employee employee = DataWorker.CopyEmployee(SelectedEmployee!);
                      EditEmployee(employee, () => DataWorker.EditEmployee(SelectedEmployee!, employee));
                  },
                  (obj) => SelectedEmployee != null));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      Employees.Remove(SelectedEmployee!);
                  },
                  (obj) => SelectedEmployee != null));
            }
        }
        #endregion

        private void EditEmployee(Employee employee, Action callBack)
        {
            EditEmployeeWindow window = new EditEmployeeWindow();
            window.DataContext = employee;

            window.Owner = Application.Current.MainWindow;

            if (window.ShowDialog() == true)
                callBack?.Invoke();
        }
    }
}
