using Data.Repository.Contracts;

namespace Data.Repository.Repositories
{
    public class TaxaJurosRepository : ITaxaJurosRepository
    {
        private const double _taxaJuros = 0.01;

        public double Get()
        {
            return _taxaJuros;
        }
    }
}
