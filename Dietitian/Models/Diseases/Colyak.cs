using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Models.Diseases
{
    public class Colyak : HastalikAbstraction
    {
        public override string ApplyDiet()
        {
            return string.Format(
                        "Colyak oldugunuz icin uygulmasi gereken diyet\n" +
                        "DiyeatAdi: {0}\nDiyetIcerigi:{1}\n", Diyet.GetDietName(), Diyet.GetDietContent());
        }

        public override string GetDiseaseName()
        {
            return "Colyak";
        }

        public override string GetDiseaseResults()
        {
            return "Glutene karsi hassasiyet";
        }
    }
}
