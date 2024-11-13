using System;
using System.Globalization;
using Matriz.Entities;
using Matriz.Entities.Enums;

namespace Matriz{
    class Program{
        static void Main(string[] args){

            Console.Write("Departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter Worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level: ");

            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salarial: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("Quantos contratos: ");
            int n = int.Parse(Console.ReadLine());

            for(int i=1; i<=n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data");
                Console.Write("Date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration: ");
                int hour = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hour);

                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Entre com mês e ano: ");
            string montEndYear = Console.ReadLine();
            int month = int.Parse(montEndYear.Substring(0,2));
            int year = int.Parse(montEndYear.Substring(3));

            Console.WriteLine("Name: "+worker.Name);
            Console.WriteLine("Department"+worker.Department.Name);
            Console.WriteLine("Income for "+montEndYear+": "+worker.Income(year,month).ToString("F2", CultureInfo.InvariantCulture));

            Console.ReadKey();
        }
    }
}