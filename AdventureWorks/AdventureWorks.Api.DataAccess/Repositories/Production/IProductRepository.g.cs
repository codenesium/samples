using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductRepository
	{
		Task<Product> Create(Product item);

		Task Update(Product item);

		Task Delete(int productID);

		Task<Product> Get(int productID);

		Task<List<Product>> All(int limit = int.MaxValue, int offset = 0);

		Task<Product> ByName(string name);

		Task<Product> ByProductNumber(string productNumber);

		Task<List<BillOfMaterial>> BillOfMaterialsByProductAssemblyID(int productAssemblyID, int limit = int.MaxValue, int offset = 0);

		Task<List<BillOfMaterial>> BillOfMaterialsByComponentID(int componentID, int limit = int.MaxValue, int offset = 0);

		Task<List<ProductCostHistory>> ProductCostHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ProductInventory>> ProductInventoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ProductListPriceHistory>> ProductListPriceHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ProductProductPhoto>> ProductProductPhotoesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ProductReview>> ProductReviewsByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<TransactionHistory>> TransactionHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<WorkOrder>> WorkOrdersByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<Product>> ByDocumentNode(int documentNode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>48d03db84d431aa0595b0651c75c5763</Hash>
</Codenesium>*/