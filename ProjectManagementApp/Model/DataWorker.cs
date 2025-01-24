using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Model
{
    public static class DataWorker
    {
        private static ObservableCollection<Employee> Employees;
        private static ObservableCollection<Project> Projects;
        static DataWorker()
        {
            Employees = new ObservableCollection<Employee>()
            {
                new Employee()
                {
                    Name = "Name1",
                    Surname = "Surname1",
                    Patronymic = "Patronymic1",
                    Email = "name1@mail"
                },
                new Employee()
                {
                    Name = "Name2",
                    Surname = "Surname2",
                    Patronymic = "Patronymic2",
                    Email = "name2@mail"
                }
            };
            Projects = new ObservableCollection<Project>()
            {
                new Project()
                {
                    Name = "Project1",
                    CustomerCompany = "Company1",
                    ExecutingCompany = "Company2",
                    Employees = new ObservableCollection<Employee>(),
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Priority = 5
                }
            };
        }

        public static ObservableCollection<Employee> GetAllEmployees()
        {
            return Employees;
        }
        public static ObservableCollection<Project> GetAllProjects()
        {
            return Projects;
        }
        public static Employee CopyEmployee(Employee employee)
        {
            return new Employee()
            {
                Name = employee.Name,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Email = employee.Email
            };
        }
        public static void EditEmployee(Employee original, Employee edited)
        {
            original.Name = edited.Name;
            original.Surname = edited.Surname;
            original.Patronymic = edited.Patronymic;
            original.Email = edited.Email;
        }
    }
}
