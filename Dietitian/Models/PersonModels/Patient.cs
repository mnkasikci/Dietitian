using Dietitian.Models.Diseases;
using System.Text.Json.Serialization;

namespace Dietitian.Models.PersonModels
{
    public class Patient
    {
        public string HastaAdi { get; set; }

        
        public string DogumYili { get; set; }
        [JsonIgnore]
        public HastalikAbstraction Hastalik { get; set; }

        public Patient(string hastaAdi, string dogumYili, HastalikAbstraction ha)
        {
            HastaAdi = hastaAdi;
            DogumYili = dogumYili;
            Hastalik = ha;
        }
    }
}
