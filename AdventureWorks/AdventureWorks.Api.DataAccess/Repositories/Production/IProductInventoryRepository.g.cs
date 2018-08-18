using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductInventoryRepository
	{
		Task<ProductInventory> Create(ProductInventory item);

		Task Update(ProductInventory item);

		Task Delete(int productID);

		Task<ProductInventory> Get(int productID);

		Task<List<ProductInventory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a89594bd48f1cc9d393934b3d8d95d19</Hash>
</Codenesium>*/