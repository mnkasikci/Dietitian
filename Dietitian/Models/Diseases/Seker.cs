using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Models.Diseases
{
    public class Seker : HastalikAbstraction
    {
        public override string ApplyDiet()
        {
            return string.Format(
                        "Seker hastasi oldugunuz icin omrunuz boyunca su diyeti uygulayin\n" +
                        "DiyeatAdi: {0}\nDiyetIcerigi:{1}\n", Diyet.GetDietName(), Diyet.GetDietContent());
        }

        public override string GetDiseaseName()
        {
            return "Seker";
        }

        public override string GetDiseaseResults()
        {
            return "Kan sekerinin yuksek olmasi";
        }
    }
}
