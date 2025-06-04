using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoInterdisciplinar.Data;
using ProjetoInterdisciplinar.Models;
using ProjetoInterdisciplinar.ViewModels;

namespace ProjetoInterdisciplinar.Controllers
{
    public class VagasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUsers> _userManager;

        public VagasController(AppDbContext context, UserManager<AppUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult VagasList()
        {
            var vagas = _context.Vagas
                        .Include(v => v.PJ)
                        .ToList();

            return View(vagas);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult VagasListAdmin()
        {
            var vagas = _context.Vagas.ToList();

            return View(vagas);
        }


        [Authorize(Roles = "PJ")]
        public async Task<IActionResult> VagasListPJ()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var vagas = await _context.Vagas.Where(v => v.PJId == user.Id).ToListAsync();

            return View(vagas);
        }



        [Authorize(Roles = "PJ, Admin")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VagaDtoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                if (user.Discriminator == "PJ")
                {
                    Vaga vaga = new Vaga()
                    {
                        Cargo = model.Cargo,
                        //Descricao = model.Descricao,
                        Salario = model.Salario,
                        PJId = user.Id
                    };

                    _context.Vagas.Add(vaga);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("VagasListPJ", "Vagas");
                }
                if (user.Discriminator == "Admin")
                {
                    Vaga vaga = new Vaga()
                    {
                        Cargo = model.Cargo,
                        //Descricao = model.Descricao,
                        Salario = model.Salario,
                    };

                    _context.Vagas.Add(vaga);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("VagasListAdmin", "Vagas");
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }


        [Authorize(Roles = "PJ, Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);

            if (vaga == null)
            {
                // criar page não achado e forbid
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null || (user.Discriminator == "PJ" && vaga.PJId != user.Id))
            {
                // criar page não achado e forbid
                return RedirectToAction("AccessDenied", "Home");
            }


            ViewData["VagaId"] = vaga.Id;


            if (user.Discriminator == "PJ")
            {
                var model = new VagaDtoViewModel
                {
                    Cargo = vaga.Cargo,
                    Salario = vaga.Salario,
                };

                return View(model);
            }
            else
            {
                var model = new VagaDtoViewModel
                {
                    Cargo = vaga.Cargo,
                    Salario = vaga.Salario,
                };

                return View(model);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VagaDtoViewModel VagaDto, int id)
        {
            var user = await _userManager.GetUserAsync(User);

            var vaga = await _context.Vagas.FindAsync(id);

            if (vaga == null)
            {
                // criar page não achado e forbid
                return RedirectToAction("Index", "Home");
            }

            if (user == null || (user.Discriminator == "PJ" && vaga.PJId != user.Id))
            {
                // criar page não achado e forbid
                return RedirectToAction("AccessDenied", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(VagaDto);
            }

            vaga.Cargo = VagaDto.Cargo;
            //obj.Descricao = VagaDto.Descricao;
            vaga.Salario = VagaDto.Salario;
            //obj.Able = VagaDto.Able;

            await _context.SaveChangesAsync();

            if (user.Discriminator == "PJ")
            {
                return RedirectToAction("VagasListPJ", "Vagas");
            }
            if (user.Discriminator == "Admin")
            {
                return RedirectToAction("VagasListAdmin", "Vagas");
            }
            
            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);


            if (vaga == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null || (user.Discriminator == "PJ" && vaga.PJId != user.Id))
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            _context.Vagas.Remove(vaga);
            _context.SaveChanges();

            if (user.Discriminator == "PJ")
            {
                return RedirectToAction("VagasListPJ", "Vagas");
            }
            if (user.Discriminator == "Admin")
            {
                return RedirectToAction("VagasListAdmin", "Vagas");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
