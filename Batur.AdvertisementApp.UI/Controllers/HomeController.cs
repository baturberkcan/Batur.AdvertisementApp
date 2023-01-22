using Batur.AdvertisementApp.Business.Interfaces;
using Batur.AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService providedService, IAdvertisementService advertisementService)
        {
            _providedService = providedService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedService.GetAllAsync();
            return this.ResponseView(response);
        }
        public async Task<IActionResult> HumanResources()
        {
            var response =await _advertisementService.GetActivitiesAsync();
            return this.ResponseView(response);
        }

    }
}
