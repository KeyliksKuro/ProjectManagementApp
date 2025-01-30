using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Model
{
    public class Employee : PropertyChangedBase
    {
        private string name;
        private string surname;
        private string patronymic;
        private string email;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged();
            }
        }
        public string Patronymic
        {
            get => patronymic;
            set
            {
                patronymic = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return $"{Surname} {Name}";
        }
    }
}
