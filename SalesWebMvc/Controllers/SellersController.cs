using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using System.Security.Cryptography.X509Certificates;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _selerService;
        private readonly DepartamentService _departamentService;


        public SellersController(SellerService selerService, DepartamentService departamentService)
        {
            _selerService = selerService;
            _departamentService = departamentService;
        }


        public IActionResult Index()            //chamando o controlador.
        {
            var list = _selerService.FindAll(); //Atribuindo o serviço para list.
            return View(list);                  // Enviando a list para a View.
        }

        public IActionResult Create()
        {
            var departaments = _departamentService.FindAll();   //buscar os departamentos do DepartamentService
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost] //ação de post e não de Get
        [ValidateAntiForgeryToken] //contra ataques CRRS
        public IActionResult Create(Seller seller)
        {
            _selerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _selerService.FindbyId(id.Value); //pega o obj.
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _selerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _selerService.FindbyId(id.Value); //pega o obj.
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _selerService.FindbyId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Departament> departaments = _departamentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departaments = departaments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _selerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch(DbConcurrencyException)
            {
                return BadRequest();
            }       
        
        
        }



    }


}
