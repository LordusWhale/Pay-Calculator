namespace ProjectOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> employeeList = DataImporter.ImportEmployee();

            foreach (Employee emp in employeeList)
            {
                emp.GeneratePayslip(20m);
            }
        }
    }
}