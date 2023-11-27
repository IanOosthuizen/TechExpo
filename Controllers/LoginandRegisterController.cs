using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using TechSPO.Models;

namespace TechSPO.Controllers
{
    public class LoginandRegisterController : Controller
    {
        private TechspoContext db = new TechspoContext();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string passwordhash)
        {
            string hash = ComputeHash(passwordhash);
            var connect = db.Users.Where(user => user.Username.Equals(username) && user.PasswordHash.Equals(hash)).FirstOrDefault();
            if(connect != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {

            using (TechspoContext db = new TechspoContext())
            {
                try
                {
                    
                
                        System.Threading.Thread.Sleep(200);
                        var check = db.Users.Where(x => x.Email == user.Email && x.Username == user.Username).FirstOrDefault();

                        if (check != null)
                        {
                            TempData["UsernameOrEmail"] = "Username or Email already in use!";
                            return View();
                        }
                        else
                        {

                            string hashed = ComputeHash(user.PasswordHash);
                            user.PasswordHash = hashed;


                            db.Users.Add(user);
                            db.SaveChanges();


                            TempData["SuccessMessage"] = user.Username + " you are Successfully registered!";
                            return RedirectToAction("Login");
                        }

                    }
                
                catch (Exception)
                {

                    ViewBag.Error = "Something went wrong";
                }


                return View();

            }
        }

        //This method is used to hash a password for security
        public static string ComputeHash(string info)   //(SkillCafe, 2021).
        {
            // I created a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // The ComputeHash returns a byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(info));


                //The byte array has been converted into a string
                StringBuilder b = new StringBuilder();
                for (int x = 0; x < bytes.Length; x++)
                {
                    b.Append(bytes[x].ToString("x2"));
                }
                return b.ToString();
            }
        }
    }
}
