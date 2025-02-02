using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Model
{
    public class Project : PropertyChangedBase
    {
        private string name;
        private string customerCompany;
        private string executingCompany;
        private Employee projectManager;
        private DateTime start;
        private DateTime end;
        private int priority;

        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string CustomerCompany
        {
            get => customerCompany; set
            {
                customerCompany = value;
                OnPropertyChanged();
            }
        }
        public string ExecutingCompany
        {
            get => executingCompany; set
            {
                executingCompany = value;
                OnPropertyChanged();
            }
        }
        public Employee ProjectManager
        {
            get => projectManager; set
            {
                projectManager = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Employee>? Employees { get; set; }
        public DateTime Start
        {
            get => start; set
            {
                start = value;
                OnPropertyChanged();
            }
        }
        public DateTime End
        {
            get => end; set
            {
                end = value;
                OnPropertyChanged();
            }
        }
        public int Priority
        {
            get => priority; set
            {
                priority = value;
                OnPropertyChanged();
            }
        }

    }
}
