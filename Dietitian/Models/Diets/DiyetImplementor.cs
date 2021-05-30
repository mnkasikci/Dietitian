using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Dietitian.Models.Diets
{
    public abstract class DiyetImplementor
    {
        public abstract string GetDietName();

        public DietPlan GetDietContent()
        {
            string mainFolderPath = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
            string classname = GetType().Name;
            string fullpath = Path.Combine(mainFolderPath, "AppData", classname) + ".json";
            
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            string jsontext = File.ReadAllText(fullpath);

            DietPlan dp = (DietPlan)JsonSerializer.Deserialize(jsontext, typeof(DietPlan), options);
            return dp;
        }
    }
}