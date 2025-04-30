using ExamShvets.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShvets.ViewModels
{
    internal class MainWindowViewModel
    {
        public List<PartnerDTO> Partners { get; set; }
        private readonly ExamShvetsContext _context = new();
        public MainWindowViewModel()
        {
            LoadData();
        }
        private void LoadData()
        {
            List<PartnerDTO> partnerDTOs = new();
            var partnerProducts = _context.PartnersImports.Include(p => p.PartnerProductsImports).Include(p => p.PartnerType).ToList();

            foreach (var part in partnerProducts)
            {
                partnerDTOs.Add(new PartnerDTO
                {
                    Phone = part.PhonePartner,
                    Name = part.Title,
                    Position = part.Director,
                    Rating = part.Rating,
                    Type = part.PartnerType.Title,
                    Discount = CalculateDiscount(part.PartnerProductsImports.Select(p => p.Count).Sum())
                }) ;
            }
            Partners = partnerDTOs;

        }

        private int CalculateDiscount(int sales)
        {
            int result;
            switch(sales)
            {
                case < 10000:
                    result = 0;
                    break;
                case < 50000:
                    result = 5;
                    break;
                case < 300_000:
                    result = 10;
                    break;
                case > 300_000:
                    result = 15;
                    break;
                default:
                    result = 0;
                    break;                  
                    
            }
            return result;
                
        }
    }
}
