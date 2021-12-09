using assignment.Data;
using assignment.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AccountRepo AR = new AccountRepo(_context);
            var query = AR.GetAll(User.Identity.Name);
            return View(query);
        }

        public IActionResult Details(int accountNumber)
        {
            AccountRepo AR = new AccountRepo(_context);
            var query = AR.GetDetails(accountNumber);
            return View(query);
        }

        public IActionResult Edit(int accountNumber)
        {
            AccountRepo AR = new AccountRepo(_context);
            var query = AR.editDetails(accountNumber, User.Identity.Name);
            return View(query);
        }
    }
}
