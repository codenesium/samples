using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductInventoryRepository
	{
		Task<ProductInventory> Create(ProductInventory item);

		Task Update(ProductInventory item);

		Task Delete(int productID);

		Task<ProductInventory> Get(int productID);

		Task<List<ProductInventory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b4e5777e3fac7b6c0bb35305de925807</Hash>
</Codenesium>*/