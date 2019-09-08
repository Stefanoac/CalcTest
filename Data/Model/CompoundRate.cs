using System;

namespace CalcTest.Data.Model
{
    public class CompoundRate
    {
        public decimal Value { get; private set; }
        public int Months { get; private set; }
        public double Rate { get; private set; }
        public decimal ReturnValue => this.Calculate;

        public CompoundRate(decimal value, double rate, int months)
        {
            this.Value = value;
            this.Rate = rate;
            this.Months = months;
        }

        private decimal Calculate
        {
            get
            {
                if (!this.ValidParameters())
                {
                    throw new Exception("Invalid parameters");
                }

                //Calcula o valor com todas as casas decimais
                decimal pow = (decimal) Math.Pow((1 + this.Rate), this.Months);

                //Pega o valor com as duas casas sem arredondamento
                return Math.Truncate((this.Value * pow) * 100) / 100;
            }
        }

        private bool ValidParameters() => this.Value > 0 && this.Rate > 0 && this.Months > 0;
    }
}
