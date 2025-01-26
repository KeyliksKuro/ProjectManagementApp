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
        public string Name { get; set; }
        public string CustomerCompany { get; set; }
        public string ExecutingCompany { get; set; }
        public Employee ProjectManager { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Priority { get; set; }

    }
}
