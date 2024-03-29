using System;
using CalcTest.Contracts.Interest;
using Microsoft.AspNetCore.Mvc;

namespace CalcTest.InterestRate.Controllers
{
    [Route("taxaJuros")]
    [ApiController]
    public class InterestRateController : Controller
    {
        private readonly IInterestRateRepository repository;

        public InterestRateController(IInterestRateRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<double> Get() => this.repository.Get();
    }
}
