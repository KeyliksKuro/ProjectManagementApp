using ProjectManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModel.ProjectWizard
{
    class EmployeesSelectionVM : WizardBaseVM
    {
        public override string Title => "Выбор сотрудников";
        public Employee? ProjectManager { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public EmployeesSelectionVM()
        {
            Employees = new ObservableCollection<Employee>();
        }
        public override bool IsValid()
        {
            return ProjectManager != null
                && Employees.Count > 0;
        }

        public override void SendData(Project project)
        {
            project.ProjectManager = ProjectManager!;
            project.Employees = Employees;
        }
    }
}
