using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductRepository
        {
                Task<Product> Create(Product item);

                Task Update(Product item);

                Task Delete(int productID);

                Task<Product> Get(int productID);

                Task<List<Product>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Product> GetName(string name);
                Task<Product> GetProductNumber(string productNumber);

                Task<List<BillOfMaterials>> BillOfMaterials(int componentID, int limit = int.MaxValue, int offset = 0);
                Task<List<ProductCostHistory>> ProductCostHistories(int productID, int limit = int.MaxValue, int offset = 0);
                Task<List<ProductDocument>> ProductDocuments(int productID, int limit = int.MaxValue, int offset = 0);
                Task<List<ProductInventory>> ProductInventories(int productID, int limit = int.MaxValue, int offset = 0);
                Task<List<ProductListPriceHistory>> ProductListPriceHistories(int productID, int limit = int.MaxValue, int offset = 0);
                Task<List<ProductProductPhoto>> ProductProductPhotoes(int productID, int limit = int.MaxValue, int offset = 0);
                Task<List<ProductReview>> ProductReviews(int productID, int limit = int.MaxValue, int offset = 0);
                Task<List<TransactionHistory>> TransactionHistories(int productID, int limit = int.MaxValue, int offset = 0);
                Task<List<WorkOrder>> WorkOrders(int productID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>af2940cb61db3ea1a3af5700e6e2f29a</Hash>
</Codenesium>*/