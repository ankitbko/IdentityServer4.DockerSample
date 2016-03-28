using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System.Linq;

namespace SampleApi.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class IdentityController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Json(User.Claims.Select(c => new { c.Type, c.Value }));
        }
    }
}