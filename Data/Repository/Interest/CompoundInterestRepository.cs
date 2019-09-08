using CalcTest.Contracts.Interest;
using CalcTest.Data.Model;

namespace CalcTest.Data.Repository.Interest
{
    public class CompoundInterestRepository : ICompoundInterestRepository
    {
        public decimal Get(decimal value, double rate, int months)
        {
            var compoundRate = new CompoundRate(value, rate, months);

            return compoundRate.ReturnValue;
        }
    }
}
