using Eventos.Domain.DTOs.InputModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.WebUi.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Index()
            => View();

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarUsuarioInputModel model)
        {
            return View();
        }
    }
}
