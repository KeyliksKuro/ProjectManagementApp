using ProjectManagementApp.Model;
using ProjectManagementApp.Utilities;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace ProjectManagementApp.ViewModel.ProjectWizard
{
    class AddProjectVM : ViewModelBase
    {
        private WizardBaseVM currentPage;
        private List<WizardBaseVM> pages;
        public Project Project { get; set; }

        public event Action CompleteFilling;
        private event Action<Project> DataIsFilled;

        public AddProjectVM()
        {
            CreatePages();
            CurrentPage = Pages.First();
        }

        #region PROPERTIES
        public WizardBaseVM CurrentPage
        {
            get { return currentPage; }
            private set
            {
                if (value == currentPage)
                    return;

                currentPage = value;

                OnPropertyChanged();
                OnPropertyChanged("IsOnLastPage");
            }
        }
        public List<WizardBaseVM> Pages
        {
            get => pages;
        }
        public bool IsOnLastPage
        {
            get => CurrentPageIndex == Pages.Count - 1;
        }
        int CurrentPageIndex
        {
            get => Pages.IndexOf(CurrentPage);
        }
        #endregion

        #region COMMANDS
        private RelayCommand moveNextCommand;
        public RelayCommand MoveNextCommand
        {
            get
            {
                return moveNextCommand ??
                    (moveNextCommand = new RelayCommand(obj =>
                    {
                        if (CurrentPageIndex < Pages.Count - 1)
                            CurrentPage = Pages[CurrentPageIndex + 1];
                        else
                            OnCompleteFilling();
                    },
                    (obj) => CurrentPage.IsValid()));
            }
        }

        private RelayCommand movePreviousCommand;
        public RelayCommand MovePreviousCommand
        {
            get
            {
                return movePreviousCommand ??
                    (movePreviousCommand = new RelayCommand(obj =>
                    {
                        CurrentPage = Pages[CurrentPageIndex - 1];
                    },
                    (obj) => 0 < CurrentPageIndex));
            }
        }
        #endregion

        /// <summary>
        /// Creating wizard pages and registering to receive data from them
        /// </summary>
        private void CreatePages()
        {
            pages = new List<WizardBaseVM>
            {
                new FillingProjectData(),
                new FillingCompaniesDataVM(),
                new EmployeesSelectionVM()
            };
            foreach (var page in pages)
            {
                DataIsFilled += page.SendData;
            }
        }
        private void OnCompleteFilling()
        {
            DataIsFilled?.Invoke(Project);
            CompleteFilling?.Invoke();
        }
    }
}
