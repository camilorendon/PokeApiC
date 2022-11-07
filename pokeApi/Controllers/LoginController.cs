using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pokeApi.Models;

namespace pokeApi.Controllers
{

    public class LoginController : Controller
    {
        private readonly PokeApiContext _context;
        public LoginController(PokeApiContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult register()
        {
            return View();
        }

        private bool loginValidate([Bind("Correo,Contraseña")] Usuario usuario)
        {
            return usuario != null;

        }


        public Usuario registerUser([Bind("Nombre,Apellido,Correo,Contraseña")] Usuario usuario)
        {
             _context.Usuarios.Add(usuario);

            return usuario;
        }
    }
}
