using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Model
{
    public static class DataWorker
    {
        private static List<Employee> Employees;
        private static List<Project> Projects;
        static DataWorker()
        {
            Employees = new List<Employee>()
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
            Projects = new List<Project>()
            {
                new Project()
                {
                    Name = "Project1",
                    CustomerCompany = "Company1",
                    ExecutingCompany = "Company2",
                    Employees = new List<Employee>(),
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Priority = 5
                }
            };
        }

        public static List<Employee> GetAllEmployees()
        {
            return Employees;
        }
        public static List<Project> GetAllProjects()
        {
            return Projects;
        }
    }
}
