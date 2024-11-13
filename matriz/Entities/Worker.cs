using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using Matriz.Entities.Enums;

namespace Matriz.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set;}
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker(){}

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }
        public double Income(int yaer, int month)
        {
            double sum = BaseSalary;

            foreach(HourContract contract in Contracts)
            {
                if(contract.Date.Year == yaer && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}