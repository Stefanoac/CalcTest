using Contracts.Interest;

namespace Domain.Repository
{
    public class InterestRateRepository : IInterestRateRepository
    {
        private const double InterestRate = 0.01;

        public double Get() => InterestRate;
    }
}
