using System;
using System.Globalization;
using System.Net;
using Contracts.Interest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace API.CompoundInterest.Controllers
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
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(); 
            }

            try
            {
                var rate = this.GetRate();

                var value = this.repository.Get(valorinicial, rate, meses);

                return this.Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private double GetRate()
        {
            var url = this.configuration.GetValue<string>("InterestRateService:0:Url");

            // chamar api1 - restsharp para epgar o valor da taxa de juros
            var client = new RestClient(url); // TODO: COLOCA ENDEREÇO NO APP SETTINGS
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
