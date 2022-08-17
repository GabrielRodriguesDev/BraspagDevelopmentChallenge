using DevelopmentChallenge.Domain.Command;
using DevelopmentChallenge.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentChallenge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevelopmentChallengeController : ControllerBase
    {
        [HttpGet]
        [Route("mdr")]
        public async Task<IActionResult> Get([FromServices] IDevelopmentChallengeService service)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = service.GetAll();
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }
        [HttpPost]
        [Route("transaction")]
        public async Task<IActionResult> CalculateTransactionValue([FromServices] IDevelopmentChallengeService service, [FromBody] DevelopmentChallengeCommand command)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = service.calculateValue(command);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }
    }
}