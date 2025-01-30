using ProjectManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModel
{
    internal class MainWindowVM : ViewModelBase
    {
        public ProjectsTabVM ProjectsTabVM { get; set; }
        public EmployeesTabVM EmployeesTabVM { get; set; }

        public MainWindowVM()
        {
            ProjectsTabVM = new ProjectsTabVM()
            {
                Projects = DataWorker.GetAllProjects(),
                Employees = DataWorker.GetAllEmployees()
            };
            EmployeesTabVM = new EmployeesTabVM()
            {
                Employees = DataWorker.GetAllEmployees()
            };
        }
    }
}
