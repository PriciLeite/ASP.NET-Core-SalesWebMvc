using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using SalesWebMvc.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            //obj.Departament = _context.Departament.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindbyId(int id) //encontrar por:
        {
            return _context.Seller.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id);
        }                           //Inner Joinn 

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);  //encontrar
            _context.Remove(obj);                // remover   
            _context.SaveChanges();              // salvar   
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new DllNotFoundException("Id não encontrado!");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }


        }


    }

}
