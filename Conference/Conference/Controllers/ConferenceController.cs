using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Conference.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Conference.Controllers
{
    public class ConferenceController : Controller
    {

        static List<ConferenceUser> conferenceUserList = new List<ConferenceUser>();
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult AddUser() {
            return View(conferenceUserList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(ConferenceUser confereceUser) {
            
            using (var stream = new FileStream($"wwwroot/images/{confereceUser.Avatar.FileName}", FileMode.Create)) {
                confereceUser.Avatar.CopyTo(stream);
            }
            conferenceUserList.Add(confereceUser);
            JsonSerializer serializer = new JsonSerializer { Formatting = Formatting.Indented };
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"users.json")) {

                serializer.Serialize(sw, confereceUser);

            }
            TempData["Message"] = "User added";
            return RedirectToAction("AddUser");
        }
    }
}