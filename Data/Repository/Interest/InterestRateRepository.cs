using Contracts.Interest;

namespace Domain.Repository.Interest
{
    public class InterestRateRepository : IInterestRateRepository
    {
        private const double InterestRate = 0.01;

        public double Get() => InterestRate;
    }
}
