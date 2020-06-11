using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkRepository<Owner> _owner;
        private readonly IUnitOfWorkRepository<PortfileItems> _portfolies;

        public HomeController(IUnitOfWorkRepository<Owner> owner , 
            IUnitOfWorkRepository<PortfileItems> portfolies)

        {
            _owner = owner;
            _portfolies = portfolies;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {

                owner = _owner.entity.GetAll().First(),
                PortfileItems = _portfolies.entity.GetAll().ToList()


            };
            return View(homeViewModel);
        }
    }
}