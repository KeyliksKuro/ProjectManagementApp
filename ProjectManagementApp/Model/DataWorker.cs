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
        private static ObservableCollection<Employee> employees;
        private static ObservableCollection<Project> projects;
        private static List<string> customerCompanies;
        private static List<string> executingCompanies;
        private static List<int> priorities;

        static DataWorker()
        {
            employees = new ObservableCollection<Employee>()
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
                },
                new Employee()
                {
                    Name = "Name3",
                    Surname = "Surname3",
                    Patronymic = "Patronymic3",
                    Email = "name3@mail"
                },
                new Employee()
                {
                    Name = "Name4",
                    Surname = "Surname4",
                    Patronymic = "Patronymic4",
                    Email = "name4@mail"
                }
            };
            projects = new ObservableCollection<Project>()
            {
                new Project()
                {
                    Name = "Project1",
                    CustomerCompany = "Company1",
                    ExecutingCompany = "Company2",
                    ProjectManager = employees[0],
                    Employees = new ObservableCollection<Employee>()
                    {
                        employees[1]
                    },
                    Start = new DateTime(2025, 01, 10),
                    End = new DateTime(2025, 01, 20),
                    Priority = 5
                },
                new Project()
                {
                    Name = "Project2",
                    CustomerCompany = "Company1",
                    ExecutingCompany = "Company3",
                    ProjectManager = employees[2],
                    Employees = new ObservableCollection<Employee>()
                    {
                        employees[3]
                    },
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Priority = 3
                }
            };

            customerCompanies = projects.Select(x => x.CustomerCompany).Distinct().ToList();
            executingCompanies = projects.Select(x => x.ExecutingCompany).Distinct().ToList();
            priorities = projects.Select(x => x.Priority).Distinct().ToList();
        }

        public static ObservableCollection<Employee> GetAllEmployees()
        {
            return employees;
        }
        public static ObservableCollection<Project> GetAllProjects()
        {
            return projects;
        }
        public static List<string> GetAllCustomerCompanies()
        {
            return customerCompanies;
        }
        public static List<string> GetAllExecutingCompanies()
        {
            return executingCompanies;
        }
        public static List<int> GetAllPriorities()
        {
            return priorities;
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
