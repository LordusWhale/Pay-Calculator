using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    public class PayCalculator
    {
        private const decimal _superRate = 0.105m;
        public decimal hoursWorked = 0;
        public Employee emp;

        public PayCalculator(Employee emp)
        {
            this.emp = emp;
        }

        public decimal calculatePay()
        {
            decimal weeklyEarnings = emp.payRate * hoursWorked;

            decimal pay = (weeklyEarnings) - (calculateTax());
            return pay;
        }
        public decimal calculateTax()
        {
            decimal taxRateA = 0;
            decimal taxRateB = 0;
            decimal weeklyEarning = emp.payRate * hoursWorked;
            List<TaxBracket> taxListThreshold = emp.taxThresholdClaim ? DataImporter.ImportTax("taxrate-nothreshold.csv") :
                DataImporter.ImportTax("taxrate-withthreshold.csv");
            foreach (TaxBracket t in taxListThreshold)
            {
                if (t.payEnd >= weeklyEarning && weeklyEarning >=t.payStart)
                {
                    taxRateA = t.coefficientA;
                    taxRateB = t.coefficientB;
                }
            }
            decimal tax = (taxRateA * (Math.Floor(weeklyEarning) + 0.99m)) - taxRateB;
            return tax;
        }
        public decimal calculateSuperannuation()
        {
            decimal super = emp.payRate * hoursWorked * _superRate;
            return super;
        }
    }
}
