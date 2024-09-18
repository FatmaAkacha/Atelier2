using Atelier2.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Atelier2.Models
{
    public class SqlProductRepository : IRepository<Product>
    {
        private readonly AppDbContext context;
        public SqlProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Product Add(Product P)
        {
            context.Products.Add(P);
            context.SaveChanges();
            return P;
        }
        public Product Delete(int Id)
        {
            Product P = context.Products.Find(Id);
            if (P != null)
            {
                context.Products.Remove(P);
                context.SaveChanges();
            }
            return P;
        }

        public Product Get(int Id)
        {
            return context.Products.Find(Id);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public Product Update(Product t)
        {
            var Product =
         context.Products.Attach(t);
            Product.State = EntityState.Modified;
            context.SaveChanges();
            return t;
        }
    }
   
   
}
