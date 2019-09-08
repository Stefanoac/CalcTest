using CalcTest.Contracts.Showmethecode;
using Microsoft.AspNetCore.Mvc;

namespace CalcTest.CompoundInterest.Controllers
{
    [Route("showmethecode")]
    [ApiController]
    public class ShowmethecodeController : Controller
    {
        private readonly IShowmethecodeRepository repository;

        public ShowmethecodeController(IShowmethecodeRepository repository)
        {
            this.repository = repository;
        }

        public string Get(decimal valorinicial, int meses)
        {
            var githubRepository = this.repository.Get();

            return githubRepository;
        }
    }
}
