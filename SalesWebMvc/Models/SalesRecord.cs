using SalesWebMvc.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Display(Name = "Quantidade")]
        public double Amount { get; set; }

        public SaleStatus Status { get; set; }


        [Display(Name = "Vendedor")]
        public Seller Seller { get; set; }


        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;         
            Seller = seller;
        }
   
    
    
    
    
    
    }
}
