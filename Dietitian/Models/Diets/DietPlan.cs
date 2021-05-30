using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Models.Diets
{
    public record DietPlan(List<DayPlan> Days);
    public record DayPlan(List<Meal> Meals);
    public record Meal(string MealName,string MealContent);
}
