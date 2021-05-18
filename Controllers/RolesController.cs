using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupCourseWork.Data;
using GroupCourseWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GroupCourseWork.Controllers
{
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        //Add Roles From Here
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
    }
}
