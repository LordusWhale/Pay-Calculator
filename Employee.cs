using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    public class Employee : Person
    {
        private PayCalculator payCalculator;
        public decimal payRate { get; set; }
        public int id { get; set; }
        public bool taxThresholdClaim { get; set; }
        public Employee(int id, string firstName, string lastName, decimal payRate, bool taxable)
        {
            this.fistName = firstName;
            this.lastName = lastName;
            this.payRate = payRate;
            this.taxThresholdClaim = taxable;
            this.id = id;
            this.payCalculator = new PayCalculator(this);
        }

        public void GeneratePayslip(decimal hoursWorked)
        {
            string fullName = $"{fistName} {lastName}";
            DataExporter.GeneratePayslip(this.payCalculator, fullName, hoursWorked);
        }
       
    }
}
