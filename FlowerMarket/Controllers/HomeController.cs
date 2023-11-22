using FlowerMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FlowerMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBase db;


        public HomeController(ILogger<HomeController> logger, DBase idb)
        {
            _logger = logger;
            this.db = idb;
        }

        public async Task<IActionResult> Index()
        {
            List<FlowerModel> list = await db.data.ToListAsync();
            return View(list);
        }

		public async Task<IActionResult> Search(string typeSearh, string searchData)
		{
			List<FlowerModel> list = await db.data.ToListAsync();
            List<FlowerModel> filtered = new List<FlowerModel>();
			
            string sPattern = $"{searchData}(\\w*)";

			if (typeSearh == "fName")
            {
				foreach (FlowerModel flower in list)
				{
					if (Regex.IsMatch(flower.Name, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
					{
						filtered.Add(flower);
					}
				}
			}
            else if (typeSearh == "fDir")
            {
				foreach (FlowerModel flower in list)
				{
					if (Regex.IsMatch(flower.Description, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
					{
						filtered.Add(flower);
					}
				}
			}

            return View("Index", filtered);
		}

        public async Task<IActionResult> Sort(string sortFor, string sortForValue)
        {
            List<FlowerModel> list = await db.data.ToListAsync();
			List<FlowerModel> sortedList = new List<FlowerModel>();

			if (sortFor == "sName")
            {
                if(sortForValue == "minMax")
                {
					sortedList = list.OrderBy(f => f.Name).ToList();
                }
                else if(sortForValue == "maxMin")
                {
					sortedList = list.OrderBy(f => f.Name).Reverse().ToList();
				}
            }
            else if(sortFor == "sPrice")
            {
				if (sortForValue == "minMax")
				{
					sortedList = list.OrderBy(f => f.Price).ToList();
				}
				else if (sortForValue == "maxMin")
				{
					sortedList = list.OrderBy(f => f.Price).Reverse().ToList();
				}
			}

			return View("Index", sortedList);
		}


		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
