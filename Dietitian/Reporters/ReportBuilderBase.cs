using Dietitian.Models.PersonModels;

namespace Dietitian.Reporters
{
    public abstract class ReportBuilderBase
    {
        
        protected readonly DietExpert _dietitian;
        protected readonly Patient _patient;
        public ReportBuilderBase(Patient p,DietExpert d)
        {
            _patient = p;
            _dietitian = d;
        }
        public abstract string BuildDietInfo();
        public abstract string BuildFooter();
        public abstract string BuildHeader();
        public abstract string BuildPersonalInfo();
    }

}
