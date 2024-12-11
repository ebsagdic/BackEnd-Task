using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Dto_s;

namespace BackEnd_Task.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
