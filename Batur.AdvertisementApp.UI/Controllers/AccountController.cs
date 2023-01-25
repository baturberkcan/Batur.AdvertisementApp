using Batur.AdvertisementApp.Business.Interfaces;
using Batur.AdvertisementApp.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateValidator;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateValidator)
        {
            _genderService = genderService;
            _userCreateValidator = userCreateValidator;
        }

        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new UserCreateModel()
            {
                Genders = new SelectList(response.Data, "Id", "Defination")
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var response = _userCreateValidator.Validate(model);
            if (response.IsValid)
            {
                return View(model);

            }
            foreach (var item in response.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(model);
        }
    }
}
