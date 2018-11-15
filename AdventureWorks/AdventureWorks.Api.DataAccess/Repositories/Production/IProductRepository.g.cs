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

		Task<Product> ByRowguid(Guid rowguid);

		Task<List<BillOfMaterial>> BillOfMaterialsByProductAssemblyID(int productAssemblyID, int limit = int.MaxValue, int offset = 0);

		Task<List<BillOfMaterial>> BillOfMaterialsByComponentID(int componentID, int limit = int.MaxValue, int offset = 0);

		Task<List<ProductReview>> ProductReviewsByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<TransactionHistory>> TransactionHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<WorkOrder>> WorkOrdersByProductID(int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ed6ae72f49c0c0f8548d2d0643cf878d</Hash>
</Codenesium>*/