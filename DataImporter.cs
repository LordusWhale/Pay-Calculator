using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ProjectOne
{
    public class DataImporter
    {
        public static List<TaxBracket> ImportTax(string dir)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;

            string outputDir = Path.Combine(currentDir, "..", "..", "..", dir);

            List<TaxBracket> list = new List<TaxBracket>();
            using (var reader = new StreamReader(outputDir))
            {
                string line = reader.ReadLine();
                line = reader.ReadLine();



                while (line != null)
                {
                    string[] cells = line.Split(',');
                    decimal payStart = decimal.Parse(cells[0]);
                    decimal payEnd = decimal.Parse(cells[1]);
                    decimal coeffA = decimal.Parse(cells[2]);
                    decimal coeffB = decimal.Parse(cells[3]);
                    list.Add(new TaxBracket(payStart, payEnd, coeffA, coeffB));

                    line = reader.ReadLine();
                }

            }

            return list;
  
        }
        public static List<Employee> ImportEmployee()
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;

            string outputDir = Path.Combine(currentDir, "..", "..", "..", "employee.csv");

            List<Employee> list = new List<Employee>();

            using (var reader = new StreamReader(outputDir))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    string[] cells = line.Split(',');
                    int id = int.Parse(cells[0]);
                    string fName = cells[1];
                    string lName = cells[2];
                    decimal payRate = decimal.Parse(cells[3]);
                    bool taxable = false;
                    if (cells[4] == "Y")
                    {
                        taxable = true;
                    }
                    list.Add(new Employee(id, fName, lName, payRate, taxable));

                    line = reader.ReadLine();
                }
            }
            return list;
        }
    }
}
