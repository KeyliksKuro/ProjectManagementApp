using ProjectManagementApp.Model;

namespace ProjectManagementApp.ViewModel.ProjectWizard
{
    abstract class WizardBaseVM : ViewModelBase
    {
        public abstract string Title { get; }
        public abstract bool IsValid();
        public abstract void SendData(Project project);
    }
}
