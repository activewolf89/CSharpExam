using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessionalNetwork.Models;
namespace ProfessionalNetwork.Controllers
    {
        public class ProfessionalController: Controller
        {
            private ProfessionalPlannerContext _context;

            public ProfessionalController(ProfessionalPlannerContext context)
            {
            _context = context;
            }
            [HttpGet]
            [Route("professional_profile")]
            
            public IActionResult Professional()
            {
                if(HttpContext.Session.GetInt32("user_id") == null)
                {
                    return RedirectToAction("Index","Home");
                }
                ViewData["FirstName"] = HttpContext.Session.GetString("Name");

                User loggedUser = _context.User.SingleOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("user_id"));
                ViewBag.userInfo = loggedUser;
                List<Network>myUserNetworkList = _context.Network
                .Where(net => net.UserConnectedId == (int)HttpContext.Session.GetInt32("user_id"))
                .Include(user => user.User)
                .ToList();
                ViewBag.myUserNetworkList = myUserNetworkList;
                
                return View();
            }
            [HttpGet]
            [Route("users")]
            public IActionResult users()
            {
                List<User> userListNotConnected = _context.User
                .Include(u => u.Networks)
                .ToList();
                ViewBag.userListNotConnected = userListNotConnected;
                ViewBag.loggedUser = (int)HttpContext.Session.GetInt32("user_id");
                ViewBag.loggedUserInfo = _context.User.SingleOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("user_id"));
                return View();
            }
            [HttpGet]
            [Route("users/{user_id}")]
            public IActionResult individualuser(int user_id)
            {
                User aIndividualUser = _context.User.SingleOrDefault(u => u.UserId == user_id);
                ViewBag.aIndividualUser = aIndividualUser;
                return View("individualuser");
            }
            [HttpGet]
            [Route("connect/{requestedConnectId}")]
            public IActionResult connect(int requestedConnectId)
            {
                int requestorConnectId = (int)HttpContext.Session.GetInt32("user_id");
                Network connectingTwo = new Network{
                    Created_At = DateTime.Now,
                    UserConnectedId = requestedConnectId,
                    UserId = requestorConnectId,
                    Status = "Pending"
                };
                _context.Add(connectingTwo);
                _context.SaveChanges();
                return RedirectToAction("users");
            }
            [HttpGet]
            [Route("ignore/{network_id}")]
            public IActionResult ignore(int network_id)
            {
                Network aNetworkId = _context.Network.SingleOrDefault(x => x.NetworkId == network_id);
                _context.Remove(aNetworkId);
                _context.SaveChanges();
                return RedirectToAction("Professional");
            }
            [HttpGet]
            [Route("accept/{network_id}")]
            public IActionResult accept(int network_id)
            {
                
                Network aNetworkId = _context.Network.SingleOrDefault(x => x.NetworkId == network_id);
                aNetworkId.Status = "Accepted";
                _context.SaveChanges();
                return RedirectToAction("Professional");
                
            }
            
            [HttpGet]
            [Route("logout")]
            public IActionResult logout()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index","Home");
            }
        }
    }