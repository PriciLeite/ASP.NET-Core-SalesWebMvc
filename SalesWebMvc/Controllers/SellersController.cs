using Microsoft.AspNetCore.Mvc;
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
    
        
    
    
    
    
    }
}
