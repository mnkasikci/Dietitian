using Dietitian.Models.Diets;

namespace Dietitian.Models.Diseases
{
    public abstract class HastalikAbstraction
    {

        public DiyetImplementor Diyet;
        public abstract string ApplyDiet();

        
        public abstract string GetDiseaseName();
        public abstract string GetDiseaseResults();
    }
}