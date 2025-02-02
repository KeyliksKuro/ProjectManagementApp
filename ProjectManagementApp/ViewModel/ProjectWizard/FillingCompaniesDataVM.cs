using ProjectManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModel.ProjectWizard
{
    class FillingCompaniesDataVM : WizardBaseVM
    {
        public override string Title => "Заполнение данных компаний";
        public string? CustomerCompany { get; set; }
        public string? ExecutingCompany { get; set; }
        public override bool IsValid()
        {
            return CustomerCompany != null
                && ExecutingCompany != null;
        }

        public override void SendData(Project project)
        {
            project.CustomerCompany = CustomerCompany!;
            project.ExecutingCompany = ExecutingCompany!;
        }
    }
}
