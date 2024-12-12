using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Dto_s;

namespace BackEnd_Task.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            if (response.StatusCode == 200)
            {
                return new ObjectResult(response) { StatusCode = response.StatusCode };
            }

            switch (response.StatusCode)
            {
                case 400:
                    return BadRequest(response);
                case 404:
                    return NotFound(response);
                case 500:
                    return StatusCode(500, response);
                default:
                    return StatusCode(response.StatusCode, response);
            }
        }
    }
}
