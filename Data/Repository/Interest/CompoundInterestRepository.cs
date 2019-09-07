using System;
using System.Collections.Generic;
using System.Text;
using Contracts.Interest;
using Domain.Model;

namespace Data.Repository.Interest
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
