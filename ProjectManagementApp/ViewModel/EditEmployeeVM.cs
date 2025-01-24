using ProjectManagementApp.Model;
using ProjectManagementApp.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectManagementApp.ViewModel
{
    class EditEmployeeVM : ViewModelBase
    {
        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        public EditEmployeeVM(Employee employee)
        {
            Employee = employee;
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      Window window = obj as Window;
                      window.DialogResult = true;
                  }));
            }
        }
    }
}
