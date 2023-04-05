using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ITCMobility.Controllers
{
    public class Account : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
