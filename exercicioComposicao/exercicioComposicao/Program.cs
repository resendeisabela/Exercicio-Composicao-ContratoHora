using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercicioComposicao.Entities;
using exercicioComposicao.Entities.Enums;

namespace exercicioComposicao
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            string lvl = Console.ReadLine();
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), lvl);
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine());
            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            Department dept = new Department(deptName);
            Worker worker = new Worker(dept, name, level, salary);

            for (int i=0; i<n; i++)
            {
                Console.WriteLine("\nEnter #"+(i+1)+" contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double vph = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, vph, hours);
                worker.AddContract(contract);
            }

            Console.Write("\nEnter month and year to calculate income (MM/YYYY): ");
            DateTime dateIncome = DateTime.Parse(Console.ReadLine());
            string dIncome = dateIncome.ToString("MM/yyyy");
            //double auxIncome = worker.Income(dateIncome.Month, dateIncome.Year);
            Console.WriteLine("Name: "+name);
            Console.WriteLine("Department: "+deptName);
            Console.WriteLine("Income for "+dIncome+": "+worker.Income(dateIncome.Month, dateIncome.Year).ToString("F2"));
            Console.ReadLine();
        }
    }
}
