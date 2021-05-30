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
    public class JsonReportBuilder : ReportBuilderBase
    {
        private readonly JsonSerializerOptions options;
        bool firstCall = true;
        public JsonReportBuilder(Patient p, DietExpert d) : base(p, d) 
        {
            options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
        }

        public override string BuildDietInfo()
        {
           // byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(_patient.Hastalik.Diyet.GetDietContent());
            var content =  JsonSerializer.Serialize(_patient.Hastalik.Diyet.GetDietContent(), options);
            content = content.Substring(1, content.Length - 2);

            if (firstCall) content += ',';
            firstCall = false;


            return content ;
        }

        public override string BuildFooter()
        {
            return "}";
        }
        public override string BuildHeader()
        {
            return 
                "{" + $"\"Diyetisyen\": \"{_dietitian.Name}\","+
                      $"\"Diyet Turu\": \"{_patient.Hastalik.Diyet.GetDietName()}\",";
        }
        public override string BuildPersonalInfo()
        {
            var content = JsonSerializer.Serialize(_patient, options);
            content = content.Substring(1, content.Length - 2);

            if (firstCall) content += ',';
            firstCall = false;
            return content;
        }
    }
}
