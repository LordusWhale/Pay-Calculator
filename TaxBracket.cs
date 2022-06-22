using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    public class TaxBracket
    {
        public decimal payStart { get; private set; }
        public decimal payEnd { get; private set; }
        public decimal coefficientA { get; private set; }
        public decimal coefficientB { get; private set; }
        public TaxBracket(decimal payStart, decimal payEnd, decimal coA, decimal coB)
        {
            this.payStart = payStart;
            this.payEnd = payEnd;
            coefficientA = coA;
            coefficientB = coB;
        }

    }
}
