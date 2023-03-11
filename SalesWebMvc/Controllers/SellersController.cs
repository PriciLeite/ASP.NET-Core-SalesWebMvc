using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _selerService;


        public SellersController(SellerService selerService)
        {
            _selerService = selerService;
        }


        public IActionResult Index()            //chamando o controlador.
        {
            var list = _selerService.FindAll(); //Atribuindo o serviço para list.
            return View(list);                  // Enviando a list para a View.
        }
    
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //ação de post e não de Get
        [ValidateAntiForgeryToken] //contra ataques CRRS
        public IActionResult Create(Seller seller)
        {
            _selerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }   
    
    
    }
}
