using Contracts.Interest;

namespace Data.Repository
{
    public class InterestRateRepository : IInterestRateRepository
    {
        private const double InterestRate = 0.01;

        public double Get() => InterestRate;
    }
}
