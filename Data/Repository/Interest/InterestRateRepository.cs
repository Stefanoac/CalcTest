using CalcTest.Contracts.Interest;

namespace CalcTest.Data.Repository.Interest
{
    public class InterestRateRepository : IInterestRateRepository
    {
        private const double InterestRate = 0.01;

        public double Get() => InterestRate;
    }
}
