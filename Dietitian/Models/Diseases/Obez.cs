using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Models.Diseases
{
    public class Obez : HastalikAbstraction
    {
        public override string ApplyDiet()
        {
            return string.Format(
                        "Obezden Kurtulmak icin \n" +
                        "DiyeatAdi: {0}\nDiyetIcerigi:{1}\n", Diyet.GetDietName(), Diyet.GetDietContent());
        }

        public override string GetDiseaseName()
        {
            return "Obez";
        }

        public override string GetDiseaseResults()
        {
            return "Karaciger Yaglanmasi";
        }
    }
}
