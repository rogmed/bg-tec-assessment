using Microsoft.AspNetCore.Mvc;
using question3_AgeCalculator.Models;
using System.Diagnostics;

namespace question3_AgeCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new AgeViewModel());
        }

        [HttpPost]
        public IActionResult Index(AgeViewModel model)
        {
            if (model.DateOfBirth == null)
            {
                model.Error = "Please enter a date of birth.";
                return View(model);
            }

            var dob = model.DateOfBirth.Value;
            var now = DateTime.Now;

            if (dob > now)
            {
                model.Error = "Date of birth cannot be in the future.";
                return View(model);
            }

            // Calculate full years
            int years = now.Year - dob.Year;
            if (dob.AddYears(years) > now) years--;

            // Calculate months
            var start = dob.AddYears(years);
            int months = 0;
            while (start.AddMonths(months + 1) <= now)
            {
                months++;
            }

            // Remaining time after removing years and months
            start = start.AddMonths(months);
            var remainder = now - start;

            int totalDays = (int)remainder.TotalDays;
            int weeks = totalDays / 7;
            int days = totalDays % 7;

            int hours = remainder.Hours;
            int minutes = remainder.Minutes;
            int seconds = remainder.Seconds;

            model.Years = years;
            model.Months = months;
            model.Weeks = weeks;
            model.Days = days;
            model.Hours = hours;
            model.Minutes = minutes;
            model.Seconds = seconds;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
