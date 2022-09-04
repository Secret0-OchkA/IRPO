using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Api.Controllers
{
    /// <summary>
    /// ApiCalculatro with base functions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        ILogger logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public CalculatorController(ILogger<CalculatorController> logger) => this.logger = logger;

        /// <summary>
        /// A + B
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Sum")]
        public double Sum([FromQuery, Required] double a, [FromQuery, Required] double b)
        {
            double res = a + b;
            logger.LogInformation($"{a} + {b} = {res}");
            return res;
        }
        /// <summary>
        /// A - B
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Sub")]
        public double Sub([FromQuery, Required] double a, [FromQuery, Required] double b)
        {
            double res = a - b;
            logger.LogInformation($"{a} - {b} = {res}");
            return res;
        }
        /// <summary>
        /// A * B
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Mul")]
        public double Mul([FromQuery, Required] double a, [FromQuery, Required] double b)
        {
            double res = a * b;
            logger.LogInformation($"{a} * {b} = {res}");
            return res;
        }
        /// <summary>
        /// A / B
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Div")]
        public double Div([FromQuery, Required] double a, [FromQuery, Required] double b)
        {
            double res = a / b;
            logger.LogInformation($"{a} / {b} = {res}");
            return res;
        }
    }
}
