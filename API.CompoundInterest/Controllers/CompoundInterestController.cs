using System;
using System.Globalization;
using System.Net;
using CalcTest.Contracts.Interest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace CalcTest.CompoundInterest.Controllers
{
    [Route("calculajuros")]
    [ApiController]
    public class CompoundInterestController : Controller
    {
        private IConfiguration configuration;
        private readonly ICompoundInterestRepository repository;

        public CompoundInterestController(IConfiguration iConfig, ICompoundInterestRepository repository)
        {
            this.configuration = iConfig;
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get(decimal valorinicial, int meses)
        {
            try
            {
                if (!this.ModelState.IsValid || valorinicial <= 0 || meses <= 0)
                {
                    return this.BadRequest();
                }

                var rate = this.GetRate();

                var value = this.repository.Get(valorinicial, rate, meses);

                return this.Ok(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private double GetRate()
        {
            var url = this.configuration.GetSection("InterestRateService").GetSection("Url").Value;

            var client = new RestClient(url);
            var request = new RestRequest("taxaJuros", Method.GET);

            // execute the request
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var rate = Convert.ToDouble(response.Content, new CultureInfo("en-US"));

                return rate;
            }
            else
            {
                throw new Exception("Erro ao acessar service");
            }
        }
    }
}
