using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interest
{
    public interface ICompoundInterestRepository
    {
        decimal Get(decimal value, double rate, int months);
    }
}
