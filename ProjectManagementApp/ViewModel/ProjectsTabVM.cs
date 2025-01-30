using ProjectManagementApp.Model;
using ProjectManagementApp.Services.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModel
{
    class ProjectsTabVM : ViewModelBase
    {
        private Project? selectedProject;
        private Employee? selectedEmployeeToAdd;
        private Employee? selectedEmployeeToRemove;

        public ObservableCollection<Project> Projects { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

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

        #region MENU COMMANDS
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      SelectedEmployeeToAdd = null;
                      SelectedEmployeeToRemove = null;
                      Projects.Remove(SelectedProject!);
                  },
                  (obj) => SelectedProject != null));
            }
        }
        #endregion

        #region COMMANDS FOR EDITING PROJECT
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