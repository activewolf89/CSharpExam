using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfessionalNetwork.Models;
namespace ProfessionalNetwork.Controllers
{
    public class HomeController : Controller
    {
    private ProfessionalPlannerContext _context;
 
    public HomeController(ProfessionalPlannerContext context)
    {
        _context = context;
    }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserViewValidation newUser)
        {
         if(ModelState.IsValid)
            {
                List<User> userList = _context.User.ToList();
                foreach (User theUser in userList)
                {
                    if(theUser.Email == newUser.Email)
                    {
                        ViewData["UserExists"] = "User already in db";
                        return View("Index");
                    }
                }
                User user = new User {
                    Name = newUser.Name,
                    Email = newUser.Email,
                    Password = newUser.Password,
                    Created_At = DateTime.Now, 
                    Description = newUser.Description
                };
                _context.Add(user);
                _context.SaveChanges();
                User aUser = _context.User
                .SingleOrDefault(u => u.Email == user.Email);
                HttpContext.Session.SetString("Name", user.Name);
                HttpContext.Session.SetInt32("user_id", aUser.UserId);                
                
                return RedirectToAction("Professional","Professional");
            }
            return View("Index");
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(ExistingUserViewValidation existingUser)
        {
         if(ModelState.IsValid)
            {
                User myExistingUser = _context.User.SingleOrDefault(x => x.Email == existingUser.Existing_Email);
                if (myExistingUser != null && myExistingUser.Password == existingUser.Existing_Password)
                {
                HttpContext.Session.SetString("Name", myExistingUser.Name);
                HttpContext.Session.SetInt32("user_id", myExistingUser.UserId);    
                return RedirectToAction("Professional","Professional");
                }

            }
            ViewData["EmailPasswordComboFail"] = "No Email/Password Combination Could Be Found";
            return View("Index");
        }
    }
}