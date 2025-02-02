using ProjectManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModel.ProjectWizard
{
    class FillingProjectData : WizardBaseVM
    {
        public override string Title => "Заполнение данных проекта";
        public string? Name { get; set; }
        public int? Priority { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public override bool IsValid()
        {
            return Name != null
                && Priority != null
                && Start != null
                && End != null
                && Start < End;
        }
        public override void SendData(Project project)
        {
            project.Name = Name!;
            project.Priority = (int)Priority!;
            project.Start = (DateTime)Start!;
            project.End = (DateTime)End!;
        }
    }
}
