using Fonour.Application.MenuApp;
using Fonour.Application.UserApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var userId = HttpContext.Session.GetString("CurrentUserId");
            var menus = _menuAppService.GetMenusByUser(Guid.Parse(userId));
            return View(menus);
        }
    }
}
