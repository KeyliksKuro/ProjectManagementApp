using ProjectManagementApp.Model;
using ProjectManagementApp.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjectManagementApp.ViewModel.ProjectWizard
{
    class EmployeesSelectionVM : WizardBaseVM
    {
        

        private ObservableCollection<Employee> Employees { get; set; }
        public override string Title => "Выбор сотрудников";

        #region ProjectManager
        private string searchPm;
        private CollectionViewSource CvsEmployeesForPm { get; set; }
        public ICollectionView EmployeesForPmView { get => CvsEmployeesForPm.View; }
        public string SearchPm
        {
            get => searchPm;
            set
            {
                searchPm = value;
                CvsEmployeesForPm.View.Refresh();
            }
        }
        public Employee? ProjectManager { get; set; }
        #endregion

        #region EmployeesInProject
        private string searchEmployee;
        private CollectionViewSource CvsEmployees { get; set; }
        public ICollectionView EmployeesView { get => CvsEmployees.View; }
        public string SearchEmployee
        {
            get => searchEmployee;
            set
            {
                searchEmployee = value;
                CvsEmployees.View.Refresh();
            }
        }
        public Employee SelectedEmployeeToAdd { get; set; }
        public Employee SelectedEmployeeToRemove { get; set; }
        public ObservableCollection<Employee> EmployeesInProject { get; set; }
        #endregion


        public EmployeesSelectionVM()
        {
            Employees = DataWorker.GetAllEmployees();
            EmployeesInProject = new ObservableCollection<Employee>();

            CvsEmployeesForPm = new CollectionViewSource();
            CvsEmployeesForPm.Source = Employees;
            CvsEmployeesForPm.Filter += ApplySearchPm;

            CvsEmployees = new CollectionViewSource();
            CvsEmployees.Source = Employees;
            CvsEmployees.Filter += ApplySearch;
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
                      EmployeesInProject.Add(SelectedEmployeeToAdd);
                  },
                  (obj) => SelectedEmployeeToAdd != null
                      && !EmployeesInProject.Contains(SelectedEmployeeToAdd)));
            }
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      EmployeesInProject.Remove(SelectedEmployeeToRemove);
                  },
                  (obj) => SelectedEmployeeToRemove != null));
            }
        }
        #endregion

        private void ApplySearchPm(object sender, FilterEventArgs e)
        {
            Employee employee = (Employee)e.Item;

            e.Accepted = SearchPm == null
                || employee.ToString().ToLower().Contains(SearchPm.ToLower());
        }
        private void ApplySearch(object sender, FilterEventArgs e)
        {
            Employee employee = (Employee)e.Item;

            e.Accepted = SearchEmployee == null
                || employee.ToString().ToLower().Contains(SearchEmployee.ToLower());
        }

        public override bool IsValid()
        {
            return ProjectManager != null
                && EmployeesInProject.Count > 0;
        }
        public override void SendData(Project project)
        {
            project.ProjectManager = ProjectManager!;
            project.Employees = EmployeesInProject;
        }
    }
}
