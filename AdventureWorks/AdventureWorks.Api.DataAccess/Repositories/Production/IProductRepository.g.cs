using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductRepository
        {
                Task<Product> Create(Product item);

                Task Update(Product item);

                Task Delete(int productID);

                Task<Product> Get(int productID);

                Task<List<Product>> All(int limit = int.MaxValue, int offset = 0);

                Task<Product> ByName(string name);

                Task<Product> ByProductNumber(string productNumber);

                Task<List<BillOfMaterial>> BillOfMaterials(int componentID, int limit = int.MaxValue, int offset = 0);

                Task<List<ProductCostHistory>> ProductCostHistories(int productID, int limit = int.MaxValue, int offset = 0);

                Task<List<ProductInventory>> ProductInventories(int productID, int limit = int.MaxValue, int offset = 0);

                Task<List<ProductListPriceHistory>> ProductListPriceHistories(int productID, int limit = int.MaxValue, int offset = 0);

                Task<List<ProductProductPhoto>> ProductProductPhotoes(int productID, int limit = int.MaxValue, int offset = 0);

                Task<List<ProductReview>> ProductReviews(int productID, int limit = int.MaxValue, int offset = 0);

                Task<List<TransactionHistory>> TransactionHistories(int productID, int limit = int.MaxValue, int offset = 0);

                Task<List<WorkOrder>> WorkOrders(int productID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>3e6002999ff9373d1c0ef1dcd2cfc77f</Hash>
</Codenesium>*/