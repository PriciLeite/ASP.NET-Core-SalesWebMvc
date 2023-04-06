using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SalesWebMvc.Models
{
    public class Departament
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Nome")]
        public string Name { get; set; }


        [Display(Name = "Vendedores")]
        [InverseProperty(nameof(Departament))]
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();


        public Departament()
        {
        }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }
  
        public void Add(Seller s)
        {
            this.Sellers.Add(s);
        }
    
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final)); //pegando todos os vendedores no intervalo de tempo do total de vendas.
        }







    
    }
}
