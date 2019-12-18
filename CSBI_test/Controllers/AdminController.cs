using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSBI_test.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSBI_test.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        ApplicationDbContext _context;
        public AdminController(ApplicationDbContext manager)
        {
            _context = manager;
        }
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }



    }


}