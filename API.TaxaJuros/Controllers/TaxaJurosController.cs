using Data.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.TaxaJuros.Controllers
{
    [Route("taxaJuros")]
    [ApiController]
    public class TaxaJurosController : Controller
    {
        private readonly ITaxaJurosRepository _repository;

        public TaxaJurosController(ITaxaJurosRepository repository)
        {
            this._repository = repository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<double> Get()
        {
            return this._repository.Get(); 
        }
    }
}
