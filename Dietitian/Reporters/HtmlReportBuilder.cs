using Dietitian.Models.PersonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Dietitian.Reporters
{
    public class HtmlReportBuilder : ReportBuilderBase
    {
        public HtmlReportBuilder(Patient p, DietExpert d) : base(p, d){}

        public override string BuildDietInfo()
        {
            string htmlText = "";
            var dietInfo = _patient.Hastalik.Diyet.GetDietContent();

            for(int i=0;i<dietInfo.Days.Count;i++)
            {
                htmlText += "<h3>" + $"{i + 1}. gün" + "</h3><br>";
                foreach (var meal in dietInfo.Days[i].Meals)
                {
                    htmlText += "<h4>" + meal.MealName + "</h4><br>";
                    htmlText += "<p>" + meal.MealContent + "</p><br>";
                }
                htmlText += "<br>";
            }
            return htmlText;
        }

        public override string BuildFooter()
        {

            return "</br>\n</body>\n</html>\n";
            
        }

        public override string BuildHeader()
        {

            string htmlText = "<!DOCTYPE html>\n" + "<html>\n" + "<body>\n";
            htmlText += "<h1> Diyet Raporu </h1><br>";
            htmlText += $"<h2> Diyetisyen: {_dietitian.Name} </h1><br>";
            htmlText += $"<h2> Diyet Turu: {_patient.Hastalik.Diyet.GetDietName()} </h2><br>";
            return htmlText;
        }

        public override string BuildPersonalInfo()
        {
            string htmlText =   $"<h3> Hasta Adı: {_patient.HastaAdi}</h3><br>";
            htmlText +=         $"<h3> Dogum Yili: {_patient.DogumYili}</h3><br>";
            return htmlText;
        }
    }
}
