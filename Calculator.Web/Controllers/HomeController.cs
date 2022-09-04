using Calculator.Client;
using Calculator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CalculatorClient calculator;

        public HomeController(ILogger<HomeController> logger, CalculatorClient calculator)
        {
            _logger = logger;
            this.calculator = calculator;
        }

        [HttpGet]
        [Route("{controller}")]
        [Route("{controller}/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] double a, [FromForm] double b, [FromForm] string op)
        {
            try
            {
                var action = op switch
                {
                    "+" => calculator.SumAsync(a, b),
                    "-" => calculator.SubAsync(a, b),
                    "*" => calculator.MulAsync(a, b),
                    "/" => calculator.DivAsync(a, b),
                };
                ViewBag.result = $"{a} {op} {b} = {await action}";
                _logger.LogInformation($"{a} {op} {b} = {await action}");
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
                return Redirect("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}