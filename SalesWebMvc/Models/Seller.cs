using SalesWebMvc.Controllers;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
       

        public int Id { get; set; }
        public string Name { get; set; }       
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        public string Email { get; set; }

        public Seller()
        {
        }

        public Seller(int id, string name, DateTime birthDate, double baseSalary, Departament departament, string email)
        {
            Id = id;
            Name = name;           
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
            Email = email;
        }

       

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial , DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }









    }
}
