﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using aammc.Areas.Manage;
using aammc.Models;
using System.Data;
using aammc.Areas.Manage.ViewModels;

namespace aammc.Areas.Manage.Controllers
{
	[Area("manage")]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		//public async Task<IActionResult> CreateAdmin()
		//{
		//	AppUser user = new AppUser
		//	{
		//		UserName = "admin",
		//		IsAdmin = true,
		//	};

		//	var result = await _userManager.CreateAsync(user, "Aammc2025");

		//	await _userManager.AddToRoleAsync(user, "Admin");

		//	return Json(result);
		//}

		//public async Task<IActionResult> CreateRoles()
		//{
		//	//await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
		//	await _roleManager.CreateAsync(new IdentityRole("Admin"));
		//	//await _roleManager.CreateAsync(new IdentityRole("Member"));

		//	return Ok();
		//}


		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(AdminLoginViewModel adminVM, string returnUrl = null)
		{
			if (adminVM.UserName == null || adminVM.Password == null)
			{
				ModelState.AddModelError("", "UserName or Password incorrect");
				return View();
			}

			AppUser user = await _userManager.FindByNameAsync(adminVM.UserName);

			if (user == null || !user.IsAdmin)
			{
				ModelState.AddModelError("", "UserName or Password incorrect");
				return View();
			}

			var result = await _signInManager.PasswordSignInAsync(user, adminVM.Password, false, false);

			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "UserName or Password incorrect");
				return View();
			}

			if (returnUrl != null) return Redirect(returnUrl);

			return RedirectToAction("index", "dashboard");
		}

		public IActionResult ShowUser()
		{
			return Json(new
			{
				isAuthenticated = User.Identity.IsAuthenticated,
			});
		}
	}

}
