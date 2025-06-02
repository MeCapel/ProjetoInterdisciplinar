using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoInterdisciplinar.Data;
using ProjetoInterdisciplinar.Models;
using ProjetoInterdisciplinar.ViewModels;

namespace ProjetoInterdisciplinar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersMngmtController : Controller
    {
        private readonly UserManager<AppUsers> userManager;
        private readonly AppDbContext _context;

        public UsersMngmtController(UserManager<AppUsers> userManager, AppDbContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            //var users = _context.Users.ToList();

            var pfUsers = _context.Users.OfType<PFUser>().ToList();
            var pjUsers = _context.Users.OfType<PJUser>().ToList();

            var viewModel = new UsersMngmtViewModel
            {
                PFUsers = pfUsers,
                PJUsers = pjUsers
            };


            return View(viewModel);
        }


        public IActionResult PFList()
        {
            var pfUsers = _context.Users.OfType<PFUser>().OrderByDescending(u => u.Id).ToList();
            return View(pfUsers);
        }


        public IActionResult PJList()
        {
            var pfUsers = _context.Users.OfType<PJUser>().OrderByDescending(u => u.Id).ToList();
            return View(pfUsers);
        }


        public IActionResult Edit(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            return user switch
            {
                PFUser pfUser => RedirectToAction("PFEdit", new { id }),
                PJUser pjUser => RedirectToAction("PJEdit", new { id }),
                _ => RedirectToAction("Index")
            };
        }


        public IActionResult PFEdit(string id)
        {
            var user = _context.Users.OfType<PFUser>().FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return RedirectToAction("Index", "UsersMngmt");
            }

            var userDto = new PFDtoViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                BirthDate = user.BirthDate,
                Sex = user.Sex,
                Able = user.Able
            };

            return View(userDto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PFEdit(PFDtoViewModel PFDto)
        {
            var user = _context.Users.OfType<PFUser>().FirstOrDefault(u => u.Id == PFDto.Id);

            if (user == null)
            {
                return RedirectToAction("PFList", "UsersMngmt");
            }

            if (!ModelState.IsValid)
            {
                return View(PFDto);
            }

            user.Name = PFDto.Name;
            user.Surname = PFDto.Surname;
            user.BirthDate = PFDto.BirthDate;
            user.Sex = PFDto.Sex;
            user.Able = PFDto.Able;

            _context.SaveChanges();

            return RedirectToAction("PFList", "UsersMngmt");
        }



        public IActionResult PJEdit(string id)
        {
            var user = _context.Users.OfType<PJUser>().FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return RedirectToAction("Index", "UsersMngmt");
            }

            var userDto = new PJDtoViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                CNPJ = user.CNPJ,
                Ramo = user.Ramo,
                Able = user.Able
            };

            return View(userDto);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PJEdit(PJDtoViewModel PJDto)
        {
            var user = _context.Users.OfType<PJUser>().FirstOrDefault(u => u.Id == PJDto.Id);

            if (user == null)
            {
                return RedirectToAction("PJList", "UsersMngmt");
            }

            if (!ModelState.IsValid)
            {
                return View(PJDto);
            }

            user.Name = PJDto.Name;
            user.CNPJ = PJDto.CNPJ;
            user.Ramo = PJDto.Ramo;
            user.Able = PJDto.Able;

            _context.SaveChanges();

            return RedirectToAction("PJList", "UsersMngmt");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return RedirectToAction("Index", "UsersMngmt");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "UsersMngmt");
        }
    }
}
