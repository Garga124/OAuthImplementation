using API.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CoffeeShopService :ICoffeeShopService
    {
        private readonly ApplicationDbContext dbContext;

        public CoffeeShopService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string OpeningHours { get; set; }
        public string Address { get; set; }

        public async Task<List<CoffeeShopModel>> List()
        {
            try
            {
                return await (from shop in dbContext.CoffeeShops select new CoffeeShopModel()
                {
                   Id = shop.Id,
                   Name = shop.Name,
                   OpeningHours = shop.OpeningHours,
                   Address = shop.Address

                }).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
            //throw new NotImplementedException();
        }
    }
}
