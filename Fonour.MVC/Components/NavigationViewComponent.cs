using Fonour.Application.MenuApp;
using Fonour.Application.UserApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fonour.Domain.Entities;
using Fonour.MVC.Common.Extensions;

namespace Fonour.MVC.Components
{
    [ViewComponent(Name = "Navigation")]
    public class NavigationViewComponent : ViewComponent
    {
        private readonly IMenuAppService _menuAppService;

        public NavigationViewComponent(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }

        public IViewComponentResult Invoke()
        {
            var user = HttpContext.Session.Get<User>("CurrentUser");
            var menus = _menuAppService.GetMenusByUser(user.Id);
            return View(menus);
        }
    }
}
