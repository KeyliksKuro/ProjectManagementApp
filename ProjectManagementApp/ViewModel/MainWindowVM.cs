namespace ProjectManagementApp.ViewModel
{
    internal class MainWindowVM : ViewModelBase
    {
        public ProjectsTabVM ProjectsTabVM { get; set; }
        public EmployeesTabVM EmployeesTabVM { get; set; }

        public MainWindowVM()
        {
            ProjectsTabVM = new ProjectsTabVM();
            EmployeesTabVM = new EmployeesTabVM();
        }
    }
}
