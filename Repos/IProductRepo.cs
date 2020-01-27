using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TShirtCompany.Models;

namespace TShirtCompany.Repos
{
    public interface IProductRepo
    {
        void AddProduct(ProductCreateVM product );
        Product GetProductByID(int id);
        IEnumerable<Product> GetAllProducts();
        void Delete(Product pro);
        void Update(Product proToUpdate);
        IEnumerable<Product> GetWomenProducts();
        IEnumerable<Product> GetMenProducts();
        IEnumerable<Product> GetMenBags();
        IEnumerable<Product> GetMenWatches();
        IEnumerable<Product> GetMenShoes();
        IEnumerable<Product> GetWomenWatches();
        IEnumerable<Product> GetWomenBags();
        IEnumerable<Product> GetWomenShoes();

    }
}
