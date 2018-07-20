using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product{ Name = "Sharp Objects", Price =12.66m},
            new Product{ Name = "Little fires everywhere", Price = 14.39m},
            new Product{ Name = "A place for us", Price =37.96m }
        }.AsQueryable<Product>();
    }
}
