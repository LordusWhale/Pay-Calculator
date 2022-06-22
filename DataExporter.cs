using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ProjectOne
{
    public class DataExporter
    {

        public static string GeneratePayslip(PayCalculator payCalc, string name, decimal hoursWorked)
        {
            payCalc.hoursWorked = hoursWorked;
            string paySlip = $"{name},{payCalc.calculatePay():C2}," +
                    $"{payCalc.calculateTax():C2},{payCalc.calculateSuperannuation():C2}";
            string basDir = AppDomain.CurrentDomain.BaseDirectory;
            string fullDir = Path.Combine(basDir, "..", "..", "..", "Payslip.csv");

            using (var sr = new StreamWriter(fullDir, true))
            {
                sr.WriteLine(paySlip);
            }
            return paySlip;
        }

    }
}
