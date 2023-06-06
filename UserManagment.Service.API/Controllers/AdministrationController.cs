using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserManagment.Service.API.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        [HttpGet("employees")]

        public IEnumerable<string> Get()
        {
            return new List<string> { "Mejreme Halilaj","Greta Isufi","Fitim Bytyqi","Agon Hamiti", "Lek Kelmendi"};
        }
    }
}
