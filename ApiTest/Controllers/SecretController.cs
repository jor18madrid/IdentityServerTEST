using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    public class SecretController : Controller
    {
        [Route("/secret")]
        [Authorize]

        public string Index()
        {
            return "Mensaje que retorna la API";
        }
    }
}
