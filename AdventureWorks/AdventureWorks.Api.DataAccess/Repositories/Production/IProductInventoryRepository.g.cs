using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductInventoryRepository
	{
		Task<ProductInventory> Create(ProductInventory item);

		Task Update(ProductInventory item);

		Task Delete(int productID);

		Task<ProductInventory> Get(int productID);

		Task<List<ProductInventory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9eeee7d52fe1ec4cfc11cf8ab6f14af0</Hash>
</Codenesium>*/