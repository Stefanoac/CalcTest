using System;
using Domain.Model;
using Xunit;

namespace CompundRate.Test
{
    public class CompoundInterestTest
    {
        private const double Rate = 0.01;

        [Fact]
        public void Value_Overflow()
        {
            var value = decimal.MaxValue;
            var months = 5;

            var compoundInterest = new CompoundRate(value, Rate, months);

            Assert.Throws<OverflowException>(() => compoundInterest.ReturnValue);
        }

        [Fact]
        public void Value_Ok()
        {
            decimal value = 100;
            var months = 5;

            var compoundInterest = new CompoundRate(value, Rate, months);

            Assert.Equal(105.10M, compoundInterest.ReturnValue);
        }

        [Fact]
        public void Value_Is_Zero()
        {
            decimal value = 0;
            var months = 5;

            var compoundInterest = new CompoundRate(value, Rate, months);

            Assert.Throws<Exception>(() => compoundInterest.ReturnValue);
        }

        [Fact]
        public void Value_Is_Negative()
        {
            decimal value = -100;
            var months = 5;

            var compoundInterest = new CompoundRate(value, Rate, months);

            Assert.Throws<Exception>(() => compoundInterest.ReturnValue);
        }

        [Fact]
        public void Months_Is_Zero()
        {
            decimal value = 100;
            var months = 0;

            var compoundInterest = new CompoundRate(value, Rate, months);

            Assert.Throws<Exception>(() => compoundInterest.ReturnValue);
        }

        [Fact]
        public void Months_Is_Negative()
        {
            decimal value = 100;
            var months = -5;

            var compoundInterest = new CompoundRate(value, Rate, months);

            Assert.Throws<Exception>(() => compoundInterest.ReturnValue);
        }
    }
}
