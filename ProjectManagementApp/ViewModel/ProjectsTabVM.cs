using ProjectManagementApp.Model;
using ProjectManagementApp.Utilities;
using ProjectManagementApp.View.ProjectWizard;
using ProjectManagementApp.ViewModel.ProjectWizard;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace ProjectManagementApp.ViewModel
{
    class ProjectsTabVM : ViewModelBase
    {
        private string? filterCustomerCompany;
        private string? filterExecutingCompany;
        private int? filterPriority;
        private DateTime? filterStartLeftBorder;
        private DateTime? filterStartRightBorder;
        private ObservableCollection<Project> Projects { get; set; }
        private CollectionViewSource CvsProjects { get; set; }
        public ICollectionView ProjectsView { get => CvsProjects.View; }
        public EditProjectVM EditProjectVM { get; set; }
        public List<string>? CustomerCompanies { get; set; }
        public List<string>? ExecutingCompanies { get; set; }
        public List<int>? Priorities { get; set; }

        public ProjectsTabVM()
        {
            EditProjectVM = new EditProjectVM();
            Projects = DataWorker.GetAllProjects();

            CvsProjects = new CollectionViewSource();
            CvsProjects.Source = Projects;
            CvsProjects.Filter += ApplyFilter;

            FillFilters();
        }

        #region PROPERTIES
        public string? FilterCustomerCompany
        {
            get => filterCustomerCompany;
            set
            {
                filterCustomerCompany = value;
                OnPropertyChanged();
            }
        }
        public string? FilterExecutingCompany
        {
            get => filterExecutingCompany;
            set
            {
                filterExecutingCompany = value;
                OnPropertyChanged();
            }
        }
        public int? FilterPriority
        {
            get => filterPriority;
            set
            {
                filterPriority = value;
                OnPropertyChanged();
            }
        }
        public DateTime? FilterStartLeftBorder
        {
            get => filterStartLeftBorder;
            set
            {
                filterStartLeftBorder = value;
                OnPropertyChanged();
            }
        }
        public DateTime? FilterStartRightBorder
        {
            get => filterStartRightBorder;
            set
            {
                filterStartRightBorder = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region MENU COMMANDS
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      var project = new Project();
                      var window = new CreationProjectWindow();
                      var vm = new AddProjectVM();
                      vm.CompleteFilling += () =>
                      {
                          Projects.Add(project);
                          window.Close();
                      };
                      window.DataContext = vm;

                      window.Owner = Application.Current.MainWindow;
                      window.ShowDialog();
                  }));
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
                      Projects.Remove(EditProjectVM.SelectedProject!);
                  },
                  (obj) => EditProjectVM.SelectedProject != null));
            }
        }
        #endregion

        #region FILTER COMMANDS
        private RelayCommand filterChangedCommand;
        public RelayCommand FilterChangedCommand
        {
            get
            {
                return filterChangedCommand ??
                  (filterChangedCommand = new RelayCommand(obj =>
                  {
                      CvsProjects.View.Refresh();
                  }));
            }
        }

        private RelayCommand filterCleanedCommand;
        public RelayCommand FilterCleanedCommand
        {
            get
            {
                return filterCleanedCommand ??
                  (filterCleanedCommand = new RelayCommand(obj =>
                  {
                      FilterCustomerCompany = null;
                      FilterExecutingCompany = null;
                      FilterPriority = null;
                      FilterStartLeftBorder = null;
                      FilterStartRightBorder = null;
                      FilterChangedCommand.Execute(this);
                  }));
            }
        }
        #endregion
        private void FillFilters()
        {
            CustomerCompanies = DataWorker.GetAllCustomerCompanies();
            ExecutingCompanies = DataWorker.GetAllExecutingCompanies();
            Priorities = DataWorker.GetAllPriorities();
        }
        private void ApplyFilter(object sender, FilterEventArgs e)
        {
            Project project = (Project)e.Item;

            e.Accepted = (FilterCustomerCompany == null || FilterCustomerCompany.Equals(project.CustomerCompany))
                && (FilterExecutingCompany == null || FilterExecutingCompany.Equals(project.ExecutingCompany))
                && (FilterPriority == null || FilterPriority.Equals(project.Priority))
                && (FilterStartLeftBorder == null || project.Start > FilterStartLeftBorder)
                && (FilterStartRightBorder == null || project.Start < FilterStartRightBorder);
        }
    }
}