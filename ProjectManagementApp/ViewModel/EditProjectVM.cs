using ProjectManagementApp.Model;
using ProjectManagementApp.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModel
{
    class EditProjectVM : ViewModelBase
    {
        private Project? selectedProject;
        private Employee? selectedEmployeeToAdd;
        private Employee? selectedEmployeeToRemove;

        public ObservableCollection<Employee> Employees { get; set; }

        public EditProjectVM()
        {
            Employees = DataWorker.GetAllEmployees();
        }

        #region PROPERTIES
        public Project? SelectedProject
        {
            get { return selectedProject; }
            set
            {
                selectedProject = value;
                OnPropertyChanged();
            }
        }
        public Employee? SelectedEmployeeToAdd
        {
            get { return selectedEmployeeToAdd; }
            set
            {
                selectedEmployeeToAdd = value;
                OnPropertyChanged();
            }
        }
        public Employee? SelectedEmployeeToRemove
        {
            get { return selectedEmployeeToRemove; }
            set
            {
                selectedEmployeeToRemove = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region COMMANDS
        private RelayCommand addEmployeeCommand;
        public RelayCommand AddEmployeeCommand
        {
            get
            {
                return addEmployeeCommand ??
                  (addEmployeeCommand = new RelayCommand(obj =>
                  {
                      SelectedProject?.Employees.Add(SelectedEmployeeToAdd!);
                  },
                  (obj) => SelectedEmployeeToAdd != null
                      && SelectedProject != null
                      && !SelectedProject.Employees.Contains(SelectedEmployeeToAdd)));
            }
        }
        private RelayCommand removeEmployeeCommand;
        public RelayCommand RemoveEmployeeCommand
        {
            get
            {
                return removeEmployeeCommand ??
                  (removeEmployeeCommand = new RelayCommand(obj =>
                  {
                      SelectedProject?.Employees.Remove(SelectedEmployeeToRemove!);
                  },
                  (obj) => SelectedEmployeeToRemove != null));
            }
        }
        #endregion
    }
}
